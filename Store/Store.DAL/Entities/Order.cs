using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DAL.Entities
{
    public class Order:BaseEntity
    {
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int PaymentId { get; set; }
    }
}
