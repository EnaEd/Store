using System;

namespace Store.DataAccessLayer.Entities
{
    public class OrderItem : BaseEntity
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public Guid PrintingEditionId { get; set; }
        public Guid OrderId { get; set; }
        public int Count { get; set; }

    }
}
