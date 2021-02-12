using System.Collections.Generic;

namespace Store.DataAccessLayer.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public IList<PrintingEdition> PrintingEditions { get; set; }
    }
}
