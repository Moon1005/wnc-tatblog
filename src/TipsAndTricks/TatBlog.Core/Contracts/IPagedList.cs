using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatBlog.Core.Contracts
{
    public interface IPagedList
    {
        //tổng số trang(số tập con)
        public int PageCount { get; set; }
        //tổng số phần tử trả về từ truy vấn
        public int TotalItemCount { get; }
        //chỉ số trang hiện tại 
        public int PageIndex { get; set; }
        //vị trí của trang hiện tại
        public int PageNumber { get; set; }
        //số lượng phần tử tối đa trên 1 trang
        public int PageSize { get; set; }
        //kiểm tra có trang trước 
        public bool HasPreviousPage { get; }
        //kiêm tra có trang tiếp theo
        public bool HasNextPage { get; }
        //trang hiện tại có phải trang đầu tiên
        public bool IsFirstPage { get; }
        //trang hiện tại có phải trang cuối cùng
        public bool IsLastPage { get; }
        //thứ tự của phần tuwr đầu trang trong truy vấn
        public int FirstItemIndex { get; }
        //thứ tự của phần tử cuối trang trong truy vấn
        public int LastItemIndex { get; }
    }

    public interface IPagedList<out T> : IPagedList, IEnumerable<T>
    {
        //lấy phần tử tại vị trí index (bắt đầu từ 0)
        public T this[int index] { get; }
        //đếm số lượng phần tử chứa trong trang
        public int Count { get; }
    }
}
