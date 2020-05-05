using System;

namespace Store.DataAccessLayer.Entities
{
    public class AuthorInPrintingEdition : BaseEntity
    {
        public Guid AuthorId { get; set; }
        public Guid PrintingEditionId { get; set; }
        public DateTime Date { get; set; }

        public Author Author { get; set; }
        public PrintingEdition Edition { get; set; }
    }
}
