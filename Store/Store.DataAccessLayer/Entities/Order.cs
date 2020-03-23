using System;

namespace Store.DataAccessLayer.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public Guid PaymentId { get; set; }
    }
}
