using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace TatBlog.WebApp.Areas.Admin.Models
{
    public class PostEditModel
    {
        public int Id { get; set; }

        [DisplayName("Tieu de")]
        //[Required(ErrorMessage = "Tieu de khong duoc de trong")]
        //[MaxLength(500, ErrorMessage = "Gioi thieu toi da 500 ky tu")]
        public string Title { get; set; }

        [DisplayName("Gioi thieu")]
        //[Required(ErrorMessage = "Gioi thieu khong duoc de trong")]
        //[MaxLength(2000, ErrorMessage = "Gioi thieu toi da 2000 ky tu")]
        public string ShortDescription { get; set; }

        [DisplayName("Noi dung")]
        //[Required(ErrorMessage = "Noi dung khong duoc de trong")]
        //[MaxLength(5000, ErrorMessage = "Noi dung toi da 5000 ky tu")]
        public string Description { get; set; }

        [DisplayName("Metadata")]
        //[Required(ErrorMessage = "Metadata khong duoc de trong")]
        //[MaxLength(1000, ErrorMessage = "Metadata toi da 1000 ky tu")]
        public string Meta { get; set; }

        [DisplayName("Slug")]
        [Remote("VerifyPostSlug", "Posts", "Admin",
            HttpMethod = "POST", AdditionalFields = "Id")]
        //[Required(ErrorMessage = "URL slug khong duoc de trong")]
        //[MaxLength(200, ErrorMessage = "Slug toi da 200 ky tu")]
        public string UrlSlug { get; set; }

        [DisplayName("Chon hinh anh")]
        public IFormFile ImageFile { get; set; }

        [DisplayName("Hinh anh hien tai")]
        public string ImageUrl { get; set; }

        [DisplayName("Xuat ban ngay")]
        public bool Published { get; set; }

        [DisplayName("Chu de")]
        //[Required(ErrorMessage = "Ban chua chon chu de")]
        public int CategoryId { get; set; }

        [DisplayName("Tac gia")]
        //[Required(ErrorMessage = "Ban chua chon tac gia")]
        public int AuthorId { get; set; }

        [DisplayName("Tu kho ( moi tu 1 dong)")]
        //[Required(ErrorMessage = "Ban chua nhap ten the")]
        public string SelectedTags { get; set; }

        public IEnumerable<SelectListItem> AuthorList { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        public List<string> GetSelectedTag()
        {
            return (SelectedTags ?? "")
                .Split(new[] { ',', ';', '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }


    }
}
