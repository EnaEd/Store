using Store.BusinessLogicLayer.Models.Base;
using Store.Shared.Enums;

namespace Store.BusinessLogicLayer.Models.PrintingEdition
{
    public class PrintingEditionFilterModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public PriceRangeModel Price { get; set; }
        public Enums.PayStatus Status { get; set; }
        public Enums.EditionType Type { get; set; }
        public Enums.Currency Currency { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
