using Store.DataAccessLayer.Models.Base;

namespace Store.DataAccessLayer.Models
{
    public class AuthorFilterDTO : OrderByDTO
    {
        public string NameFilter { get; set; }

    }
}
