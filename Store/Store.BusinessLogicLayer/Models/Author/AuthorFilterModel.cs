using Store.BusinessLogicLayer.Models.Base;

namespace Store.BusinessLogicLayer.Models.Author
{
    public class AuthorFilterModel : OrderByModel<AuthorModel>
    {
        public string NameFilter { get; set; }

    }
}
