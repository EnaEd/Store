using System;

namespace Store.DataAccessLayer.Entities
{
    public class AuthorInBook : BaseEntity
    {
        public Guid AuthorId { get; set; }
        public Guid PrintingEditionId { get; set; }
        public DateTime Date { get; set; }
    }
}
