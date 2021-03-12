namespace Store.DataAccessLayer.Models.Base
{
    public class OrderByDTO : PaginationDTO
    {
        public bool OrderByDesc { get; set; }
        public string OrderField { get; set; }
    }
}
