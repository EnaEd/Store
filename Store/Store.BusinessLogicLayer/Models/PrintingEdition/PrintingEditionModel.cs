using Store.BusinessLogicLayer.Models.Author;
using Store.BusinessLogicLayer.Models.Base;
using Store.Shared.Enums;
using System.Collections.Generic;

namespace Store.BusinessLogicLayer.Models.PrintingEdition
{
    public class PrintingEditionModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Enums.PayStatus Status { get; set; }
        public Enums.EditionType Type { get; set; }
        public Enums.Currency Currency { get; set; }
        public List<AuthorModel> Authors { get; set; }
    }
}
