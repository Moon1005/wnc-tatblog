﻿using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TatBlog.Core.Collections;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Services.Blogs;
using TatBlog.WebApi.Filters;
using TatBlog.WebApi.Models;

namespace TatBlog.WebApi.Endpoints
{
	public static class CategoryEndpoints
	{
		public static WebApplication MapCategoryEndpoints(this WebApplication app)
		{
			var routeGroupBuilder = app.MapGroup("/api/categories");

			routeGroupBuilder.MapGet("/", GetCategories)
				.WithName("GetCategories")
				.Produces<ApiResponse<PaginationResult<CategoryItem>>>();

			routeGroupBuilder.MapGet("/{id:int}", GetCategoyDetails)
				.WithName("GetCategoryById")
				.Produces<ApiResponse<CategoryItem>>();

			routeGroupBuilder.MapPost("/", AddCategory)
				.WithName("AddCategory")
				.AddEndpointFilter<ValidatorFilter<CategoryEditModel>>()
				.RequireAuthorization()
				.Produces(401)
				.Produces<ApiResponse<CategoryItem>>();

			routeGroupBuilder.MapPut("/{id:int}", UpdateCategory)
				.WithName("UpdateACategory")
				.AddEndpointFilter<ValidatorFilter<CategoryEditModel>>()
				.RequireAuthorization()
				.Produces(401)
				.Produces<ApiResponse<string>>();

			routeGroupBuilder.MapDelete("/{id:int}", DeleteCategory)
			   .WithName("DeleteCategory")
				.RequireAuthorization()
				.Produces(401)
				.Produces<ApiResponse<string>>();

			return app;
		}

		private static async Task<IResult> GetCategories([AsParameters] CategoryFilterModel model, ICategoryRepository categoryRepository)
		{
			// model kế thừa từ PagingModel
			var categories = await categoryRepository.GetPagedCategoriesAsync(model, model.Name);

			var paginationResult = new PaginationResult<CategoryItem>(categories);
			return Results.Ok(ApiResponse.Success(paginationResult));
		}

		private static async Task<IResult> GetCategoyDetails(int id, ICategoryRepository categoryRepository, IMapper mapper)
		{
			var category = await categoryRepository.GetCachedCategoryByIdAsync(id);

			return category == null
				? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy tiêu đề có mã số {id}"))
				: Results.Ok(ApiResponse.Success(mapper.Map<CategoryItem>(category)));

		}


		private static async Task<IResult> AddCategory(
			CategoryEditModel model, ICategoryRepository categoryRepository, IMapper mapper)
		{
			if (await categoryRepository.IsCategorySlugExistedAsync(0, model.UrlSlug))
			{
				//return Results.Conflict($"Slug '{model.UrlSlug}' đã được sử dụng");
				return Results.Ok(
					ApiResponse.Fail(
						HttpStatusCode.Conflict,
					$"Slug '{model.UrlSlug}' đã được sử dụng"));
			}

			var category = mapper.Map<Category>(model);
			await categoryRepository.AddOrEditCategoryAsync(category);

			//return Results.CreatedAtRoute(
			//    "GetCategoryById",
			//    new { category.Id },
			//    mapper.Map<CategoryItem>(category));

			return Results.Ok(ApiResponse.Success(
				mapper.Map<Category>(category),
				HttpStatusCode.Created));
		}

		private static async Task<IResult> UpdateCategory(
			int id,
			CategoryEditModel model,
			ICategoryRepository categoryRepository,
			IMapper mapper)
		{
			if (await categoryRepository.IsCategorySlugExistedAsync(id, model.UrlSlug))
			{
				//return Results.Conflict($"Slug '{model.UrlSlug}' đã được sử dụng");
				return Results.Ok(
					ApiResponse.Fail(
						HttpStatusCode.Conflict,
						$"Slug '{model.UrlSlug}' đã được sử dụng"));
			}

			var category = mapper.Map<Category>(model);
			category.Id = id;

			return await categoryRepository.AddOrEditCategoryAsync(category)
			   ? Results.Ok(ApiResponse.Success("Category is updated", HttpStatusCode.NoContent))
			   : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Could not find category"));

		}

		private static async Task<IResult> DeleteCategory(int id, ICategoryRepository categoryRepository)
		{
			return await categoryRepository.DeleteCategoryByIdAsync(id)
				? Results.Ok(ApiResponse.Success("Category is deleted", HttpStatusCode.NoContent))
				: Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound,
				"Could not find category"));
		}
	}
}
