using System.Collections.Generic;

namespace TestApp.API.Model
{
    public class PagedResult<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int TotalNumberOfItems { get; set; }

        public IEnumerable<T> Results { get; set; }
    }
}
