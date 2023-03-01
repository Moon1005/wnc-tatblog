﻿using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;

namespace TatBlog.WinApp
{
    public class Program
    {
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




        }
    }
}