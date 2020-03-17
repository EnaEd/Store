using System;

namespace Store.DAL.Entities
{
    public class Payments : BaseEntity
    {
        public Guid TransactionId { get; set; }
    }
}
