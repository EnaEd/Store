using System;
using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogicLayer.Models.Order
{
    public class OrderItemRequestModel
    {
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public Guid PrintingEditionId { get; set; }
        [Required]
        public int Count { get; set; }

    }
}
