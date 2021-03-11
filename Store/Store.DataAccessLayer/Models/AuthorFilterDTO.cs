namespace Store.DataAccessLayer.Models
{
    public class AuthorFilterDTO : PaginationDTO
    {
        public string NameFilter { get; set; }
        public bool OrderByDesc { get; set; }
        public string OrderField { get; set; }
    }
}
