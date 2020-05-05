using Store.BusinessLogicLayer.Models.Base;
using Store.Shared.Enums;

namespace Store.BusinessLogicLayer.Models.PrintingEdition
{
    public class PrintingEditionProfileModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Enums.PayStatus Status { get; set; }
        public Enums.EditionType Type { get; set; }
        public Enums.Currency Currency { get; set; }
        public string Author { get; set; }
    }
}
