namespace Store.BusinessLogicLayer.Models.Base
{
    public class PaginationModel<T> where T : class
    {

        public T Data { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int Count { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }
}
