using System;
using System.Collections.Generic;
using System.Text;

namespace StudentData.Services.Interfaces.ViewModel
{
    public class PagedViewModel<T>
    {
        public IEnumerable<T> Rows { get; set; }

        public int PageNumber { get; set; }

        public int PageCount { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }
    }
}
