using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DAL.Entities
{
    public class OrderItems:BaseEntity
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int PrintingEditionId { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
    }
}
