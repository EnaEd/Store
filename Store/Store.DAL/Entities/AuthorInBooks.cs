using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DAL.Entities
{
    public class AuthorInBooks:BaseEntity
    {
        public int AuthorId { get; set; }
        public int PrintingEditionId { get; set; }
        public DateTime Date { get; set; }
    }
}
