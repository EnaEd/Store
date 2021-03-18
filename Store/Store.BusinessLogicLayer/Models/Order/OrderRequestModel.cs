using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogicLayer.Models.Order
{
    public class OrderRequestModel
    {
        [Required]
        public string Description { get; set; }

        public bool IsCanceled { get; set; }
        [Required]
        public List<OrderItemRequestModel> OrderItems { get; set; }
    }
}
