using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;
using TatBlog.Core.Entities;

namespace TatBlog.Core.DTO
{
    public class PostItem : IEntity
    {
        //Mã bài viết
        public int Id { get; set; }
        //Tiêu đề bài viết
        public string Title { get; set; }
        //Mô tả hay giới thiệu ngắn về nội dung
        public string ShortDescription { get; set; }
        // nội dung chi tiết của bài viết
        public string Description { get; set; }
        //Metadata
        public string Meta { get; set; }
        //Tên định danh để tạo URL
        public string UrlSlug { get; set; }
        //đường dẫn đến tập tin hình ảnh
        public string ImageUrl { get; set; }
        //số lượt xem, đọc bài viết
        public int ViewCount { get; set; }
        //trạng thái của bài viết
        public bool Published { get; set; }
        //ngày giờ đăng bài
        public DateTime PostedDate { get; set; }
        //ngày giờ cập nhật lần cuối
        public DateTime? ModifiedDate { get; set; }
        //mã chuyên mục
        public int CategoryId { get; set; }
        //mã tác giả của bài viết
        public int AuthorId { get; set; }
        // chuyên mục của bài viết
        public Category Category { get; set; }
        public string CategoryName { get; set; }
        //tác giả của bài viết
        public Author Author { get; set; }
        //danh sách các từ khóa của bài viết
        public IList<Tag> Tags { get; set; }
    }
}
