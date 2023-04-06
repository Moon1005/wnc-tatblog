namespace TatBlog.WebApi.Models
{
	public class PostDto
	{
		//mã bài viết
		public int Id { get; set; }
		//tiêu đề bai viết
		public string Title { get; set; }
		//mô tả hay giới thiệu ngắn về nội dung
		public string ShortDescription { get; set; }
		//tên định danh để tạo URl
		public string UrlSlug { get; set; }
		//đường dẫn đến tập tin hình ảnh
		public string ImageUrl { get; set; }
		//số lượt xem, đọc bài viết
		public int ViewCount { get; set; }
		//ngày giờ đăng bài
		public DateTime PostedDate { get; set; }
		////ngày giờ cập nhật lần cuối
		public DateTime? ModifiedDate { get; set; }
		//chuyên mục của bài viết
		public CategoryDto Category { get; set;}
		//tác giả của bài viết
		public AuthorDto Author { get; set;}
		//danh sách các từ khóa của bài viết
		public IList<TagDto> Tags { get; set; }


	}
}
