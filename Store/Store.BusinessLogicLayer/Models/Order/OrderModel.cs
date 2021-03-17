using Store.BusinessLogicLayer.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogicLayer.Models.Order
{
    public class OrderModel : BaseModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public Guid PaymentId { get; set; }
        public bool IsCanceled { get; set; }
    }
}
