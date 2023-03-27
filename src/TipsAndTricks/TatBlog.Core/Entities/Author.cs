using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;

namespace TatBlog.Core.Entities
{
    public class Author : IEntity
    {
        //mã tác giả bài viết
        public int Id { get; set; }
       //tên tác giả
        public string Fullname { get; set; }

		//Tên định danh đùng để tạo URL
		public string UrlSlug { get; set; }
        //đường dẫn tới file hình ảnh
        public string ImageUrl { get; set; }
        //ngày bắt đầu
        public DateTime JoinedDate { get; set; }
        //địa chỉ email
        public string Email { get; set; }
        //ghi chú
        public string Notes { get; set; }
        //danh sách các bài viết của tác giả
        public IList<Post> Posts { get; set; }
    }
}
