using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccessLayer.Entities
{
    public class PrintingEdition : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Currency { get; set; }
        public List<Author> Authors { get; set; }

    }
}
