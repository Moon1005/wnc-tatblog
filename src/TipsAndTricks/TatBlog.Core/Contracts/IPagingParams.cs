using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatBlog.Core.Contracts
{
    public interface IPagingParams
    {
        //số mẫu tin trên một trang
        public int PageSize { get; set; }
        //số trang tinh bắt đầu từ 1
        public int PageNumber { get; set; }
        //tên cột muốn sắp xếp
        public string SortColumn { get; set; }
        //thứ tự sắp xếp: tăng hay giảm
        public string SortOrder { get; set; }
    }
}
