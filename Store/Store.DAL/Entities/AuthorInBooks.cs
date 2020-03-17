using System;

namespace Store.DAL.Entities
{
    public class AuthorInBooks : BaseEntity
    {
        public int AuthorId { get; set; }
        public int PrintingEditionId { get; set; }
        public DateTime Date { get; set; }
    }
}
