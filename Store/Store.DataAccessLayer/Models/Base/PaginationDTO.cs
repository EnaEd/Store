namespace Store.DataAccessLayer.Models.Base
{
    public class PaginationDTO
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int Count { get; set; }
    }
}
