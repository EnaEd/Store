using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccessLayer.Entities
{
    public class OrderItem : BaseEntity
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public Guid PrintingEditionId { get; set; }
        public Guid OrderId { get; set; }
        public int Count { get; set; }

    }
}
