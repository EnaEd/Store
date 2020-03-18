using System;

namespace Store.DAL.Entities
{
    public class Payment : BaseEntity
    {
        public Guid TransactionId { get; set; }
    }
}
