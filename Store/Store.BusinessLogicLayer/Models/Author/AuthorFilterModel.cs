using Store.BusinessLogicLayer.Models.Base;

namespace Store.BusinessLogicLayer.Models.Author
{
    public class AuthorFilterModel : PaginationModel<AuthorModel>
    {
        public string NameFilter { get; set; }
        public bool OrderByDesc { get; set; }
        public string OrderField { get; set; }
    }
}
