using System.Net;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;
using TatBlog.Services.Blogs;


namespace TatBlog.WinApp
{
    public class Program
    {
		public static object WebApplication { get; private set; }

		static void Main(string[] args)
        {
            // Tạo đối tượng context để quản lý phiên làm việc
            var context = new BlogDbContext();


            //Tạo đối tượng khởi tạo dữ liệu mẫu
            //var seeder = new DataSeeder(context);
            //goi ham Inititalize de nhap du lieu
            //seeder.Initialize();
            //doc danh sach tac gia tu co so du lieu
            //var authors = context.Authors.ToList();
            ////xuat danh sach tac gia ra man hinh
            //Console.WriteLine("{0,-4}{1,-30}{2,-30}{3,12:MM/dd/yyyy}",
            //    "ID", "Full Name", "Email", "Joined Date");
            //foreach (var author in authors)
            //{
            //    Console.WriteLine("{0,-4}{1,-30}{2,-30}{3,12:MM/dd/yyyy}",
            //    author.Id,author.Fullname,author.Email,author.JoinedDate);
            //}


            //lay kem ten tac gia va chuyen muc
            //var posts = context.Posts
            //    .Where(p => p.Published)
            //    .OrderBy(p =>p.Title)
            //    .Select(p=> new
            //    {
            //        Id=p.Id,
            //        Title =p.Title,
            //        ViewCount = p.ViewCount,
            //        PostedDate = p.PostedDate,
            //        Author = p.Author,
            //        Category = p.Category,
            //    })
            //    .ToList();
            ////xuat danh sach bai viet ra man hinh
            //foreach (var post in posts)
            //{
            //    Console.WriteLine("ID:{0}", post.Id);
            //    Console.WriteLine("Title:{0}", post.Title);
            //    Console.WriteLine("View:{0}", post.ViewCount);
            //    Console.WriteLine("Date:{0:MM/dd/YYYY}", post.PostedDate);
            //    Console.WriteLine("Author:{0}", post.Author);
            //    Console.WriteLine("Category:{0}", post.Category);
            //    Console.WriteLine("".PadRight(80,'-'));
            //}



            ////Tao doi tuong BlogRepository
            //IBlogRepository blogRepo = new BlogRepository(context);
            ////lay danh sachchuyen muc
            //var categories = await blogRepo.GetCategoriesAsync();
            ////xuat ra man hinh
            //Console.WriteLine("{0,-5}{1,-50}{2,10}",
            //    "ID","Name","Count");
            //foreach (var item in categories)
            //{
            //    Console.WriteLine("{0,-5}{1,-50}{2,10}",
            //        item.Id, item.Name, item.PostCount);
            //}



            //tim 3 bai viet duoc xem/ doc nhieu nhat
            //XemTopBaiDocNhieuNhat(context, 3);

            // Lay danh sach tu khoa
            LayDanhSachTuKhoa(context, "google");

            Console.ReadKey();


			
		}
            
        

        static async void XemTopBaiDocNhieuNhat(BlogDbContext context, int numPost)
        {
            //tao doi tuong BlogRepositery
            IBlogRepository blogRepo = new BlogRepository(context);
            
            var posts = await blogRepo.GetPopularArticlesAsync(numPost);
            //xuat danh sach bai viet ra man hinh
            foreach (var post in posts)
            {
                Console.WriteLine("ID:{0}", post.Id);
                Console.WriteLine("Title:{0}", post.Title);
                Console.WriteLine("View:{0}", post.ViewCount);
                Console.WriteLine("Date:{0:MM/dd/YYYY}", post.PostedDate);
                Console.WriteLine("Author:{0}", post.Author);
                Console.WriteLine("Category:{0}", post.Category);
                Console.WriteLine("".PadRight(80, '-'));
            }
        }

        static async void LayDanhSachTuKhoa(BlogDbContext context, string slug)
        {
            //tao doi tuong BlogRepository
            IBlogRepository blogRepo = new BlogRepository(context);
            //tao doi tuong chua tham so phan trang
            var pagingParams = new PagingParams
            {
                PageNumber = 1,//lay ket qua o trang so 1
                PageSize = 5,//lay 5 mau tin
                SortColumn = "Name", //sapw xep theo ten
                SortOrder = "DESC" //theo chieu giam dan
            };
            //lay danh sach tu khoa
            var tagsList = await blogRepo.GetPagedTagsAsync(pagingParams);

            //xuat ra man hinh
            Console.WriteLine("{0,-5}{1,-50}{2,10}",
                "Id", "Name", "Count");
            foreach (var item in tagsList)
            {
                Console.WriteLine("{0,-5}{1,-50}{2,10}",
                    item.Id, item.Name, item.PostCount);
            }


            //Lấy danh sach 
            //Tag tag = await blogRepo.GetTagBySlugAsync(slug);

            //xuất ra màn hình
            //Console.WriteLine("{0,-5}{1,-50}{2,10}",
            //     "Id", "Name", "Count");
            //if (tag != null)
            //{
            //    Console.WriteLine("{0,-5}{1,-50}{2,10}",
            //     tag.Id,tag.Name,tag.Posts.Count);
            //}

        }
   

    }
}