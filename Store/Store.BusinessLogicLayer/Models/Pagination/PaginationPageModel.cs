using System;

namespace Store.BusinessLogicLayer.Models.Pagination
{
    public class PaginationPageModel
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviusPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public PaginationPageModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
