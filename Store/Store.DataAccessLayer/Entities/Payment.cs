using System;

namespace Store.DataAccessLayer.Entities
{
    public class Payment : BaseEntity
    {
        public Guid TransactionId { get; set; }
    }
}
