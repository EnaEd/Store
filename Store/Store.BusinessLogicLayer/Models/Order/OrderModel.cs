using Store.BusinessLogicLayer.Models.Base;
using System;

namespace Store.BusinessLogicLayer.Models.Order
{
    public class OrderModel : BaseModel
    {
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public Guid PaymentId { get; set; }
        public bool IsCanceled { get; set; }
    }
}
