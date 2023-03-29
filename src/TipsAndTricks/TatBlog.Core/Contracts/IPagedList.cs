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
        int PageCount { get;  }
        //tổng số phần tử trả về từ truy vấn
        int TotalItemCount { get; }
        //chỉ số trang hiện tại 
        int PageIndex { get; }
        //vị trí của trang hiện tại
        int PageNumber { get; }
        //số lượng phần tử tối đa trên 1 trang
        int PageSize { get;}
        //kiểm tra có trang trước 
        bool HasPreviousPage { get; }
        //kiêm tra có trang tiếp theo
        bool HasNextPage { get; }
        //trang hiện tại có phải trang đầu tiên
        bool IsFirstPage { get; }
        //trang hiện tại có phải trang cuối cùng
        bool IsLastPage { get; }
        //thứ tự của phần tuwr đầu trang trong truy vấn
        int FirstItemIndex { get; }
        //thứ tự của phần tử cuối trang trong truy vấn
        int LastItemIndex { get; }
    }

    public interface IPagedList<out T> : IPagedList, IEnumerable<T>
    {
        //lấy phần tử tại vị trí index (bắt đầu từ 0)
         T this[int index] { get; }
        //đếm số lượng phần tử chứa trong trang
         int Count { get; }
    }
}
