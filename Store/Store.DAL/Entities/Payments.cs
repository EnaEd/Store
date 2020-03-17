using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Store.DAL.Entities
{
    public class Payments:BaseEntity
    {
        public Guid TransactionId { get; set; }
    }
}
