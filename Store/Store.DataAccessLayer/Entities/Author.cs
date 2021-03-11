using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.DataAccessLayer.Entities
{
    public class Author : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<PrintingEdition> PrintingEditions { get; set; }
    }
}
