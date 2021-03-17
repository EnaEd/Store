using System;
using System.Collections.Generic;

namespace Store.DataAccessLayer.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public Guid PaymentId { get; set; }
        public bool IsCanceled { get; set; }
        public string Test { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
