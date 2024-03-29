﻿using FluentValidation;
using FluentValidation.AspNetCore;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Services.Blogs;
using TatBlog.Services.Media;
using TatBlog.WebApp.Areas.Admin.Models;
using TatBlog.WebApp.Validations;

namespace TatBlog.WebApp.Areas.Admin.Controllers
{
	public class PostsController : Controller
	{
		private readonly ILogger<PostsController> _logger;
		private readonly IBlogRepository _blogRepository;
		private readonly IAuthorRepository _authorRepository;
		private readonly IMediaManager _mediaManager;
		private readonly IMapper _mapper;

		public PostsController(
			ILogger<PostsController> logger,
			IBlogRepository blogRepository,
			IAuthorRepository authorRepository,
			IMediaManager mediaManager,
			IMapper mapper)
		{
			_logger = logger;
			_blogRepository = blogRepository;
			_authorRepository = authorRepository;
			_mediaManager = mediaManager;
			_mapper = mapper;
		}


		public async Task<IActionResult> Index(PostFilterModel model)
		{


			_logger.LogInformation("Tao dieu kien truy van");

			var postQuery = _mapper.Map<PostQuery>(model);

			_logger.LogInformation("Lay danh sach bai viet tu CSDL");

			ViewBag.postQuery = await _blogRepository
				.GetPagedPostsAsync(postQuery, 1, 10);
			_logger.LogInformation("Chuan bi du lieu cho ViewModel");
			await PopulatePostFilterModelAsync(model);


			ViewBag.PostList = await _blogRepository.GetPagedPostsAsync(postQuery, 1, 10);

			await PopulatePostFilterModelAsync(model);

			return View(model);
		}

		private async Task PopulatePostFilterModelAsync(PostFilterModel model)
		{
			var authors = await _authorRepository.GetAuthorsAsync();
			var categories = await _blogRepository.GetCategoriesAsync();

			model.AuthorList = authors.Select(a => new SelectListItem()
			{
				Text = a.Fullname,
				Value = a.Id.ToString()
			});
			model.CategoryList = categories.Select(c => new SelectListItem()
			{
				Text = c.Name,
				Value = c.Id.ToString()
			});
		}

		private async Task PopulatePostEditModelAsync(PostEditModel model)
		{
			var authors = await _authorRepository.GetAuthorsAsync();
			var categories = await _blogRepository.GetCategoriesAsync();

			model.AuthorList = authors.Select(a => new SelectListItem()
			{
				Text = a.Fullname,
				Value = a.Id.ToString()
			});
			model.CategoryList = categories.Select(c => new SelectListItem()
			{
				Text = c.Name,
				Value = c.Id.ToString()
			});
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id = 0)
		{
			var post = id > 0
				? await _blogRepository.GetPostByIdAsync(id, true)
				: null;

			var model = post == null
				? new PostEditModel()
				: _mapper.Map<PostEditModel>(post);

			await PopulatePostEditModelAsync(model);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(
			[FromServices] IValidator<PostEditModel> postValidator,
			PostEditModel model)
		{
			var validationResult = await postValidator.ValidateAsync(model);

			if (!validationResult.IsValid)
			{
				validationResult.AddToModelState(ModelState);
			}
			
			if (!ModelState.IsValid)
			{
				await PopulatePostEditModelAsync(model);
				return View(model);
			}

			var post = model.Id > 0
				? await _blogRepository.GetPostByIdAsync(model.Id)
				: null;
			if (post == null)
			{
				post = _mapper.Map<Post>(model);

				post.Id = 0;
				post.PostedDate = DateTime.Now;
			}
			else
			{
				_mapper.Map(model, post);

				post.Category = null;
				post.ModifiedDate = DateTime.Now;
			}

			if (model.ImageFile?.Length > 0)
			{
				var newImagePath = await _mediaManager.SaveFileAsync(
					model.ImageFile.OpenReadStream(),
					model.ImageFile.FileName,
					model.ImageFile.ContentType);
				if (!string.IsNullOrWhiteSpace(newImagePath))
				{
					await _mediaManager.DeleteFileAsync(post.ImageUrl);
					post.ImageUrl = newImagePath;
				}
			}

			await _blogRepository.CreateOrUpdatePostAsync(
				post, model.GetSelectedTag());

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> VerifyPostSlug(int id, string urlSlug)
		{
			var slugExisted = await _blogRepository
				.IsPostSlugExistedAsync(id, urlSlug);

			return slugExisted
				? Json($"Slug'{urlSlug}' da duoc su dung")
				: Json(true);
		}
	}
}
