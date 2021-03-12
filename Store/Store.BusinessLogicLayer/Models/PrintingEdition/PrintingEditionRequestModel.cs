using Store.BusinessLogicLayer.Models.Author;
using Store.BusinessLogicLayer.Models.Base;
using Store.Shared.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogicLayer.Models.PrintingEdition
{
    public class PrintingEditionRequestModel : BaseModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }

        [Required]
        public Enums.PayStatus Status { get; set; }

        [Required]
        public Enums.EditionType Type { get; set; }

        [Required]
        public Enums.Currency Currency { get; set; }

        [Required]
        public List<AuthorModel> Authors { get; set; }
    }
}
