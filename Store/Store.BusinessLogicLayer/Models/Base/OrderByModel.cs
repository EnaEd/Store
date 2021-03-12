namespace Store.BusinessLogicLayer.Models.Base
{
    public class OrderByModel<T> : PaginationModel<T> where T : class
    {
        public bool OrderByDesc { get; set; }
        public string OrderField { get; set; }
    }
}
