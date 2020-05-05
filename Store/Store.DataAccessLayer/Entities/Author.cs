using System.Collections.Generic;

namespace Store.DataAccessLayer.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public IList<AuthorInPrintingEdition> AuthorInPrintingEditions { get; set; }
    }
}
