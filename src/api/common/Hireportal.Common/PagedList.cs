using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Common
{
    public class PagedList<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageCount => (int)Math.Ceiling((TotalCount == 0 ? TotalCount + 1 : TotalCount) / (double)PageSize);
        public int PageSize { get; set; }
        public int ItemCount => Items.Count;
    }
}
