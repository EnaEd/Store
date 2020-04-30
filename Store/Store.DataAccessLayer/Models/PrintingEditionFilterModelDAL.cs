using Store.DataAccessLayer.Models.Base;
using Store.Shared.Enums;

namespace Store.DataAccessLayer.Models
{
    public class PrintingEditionFilterModelDAL
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public PriceRangeModelDAL Price { get; set; }
        public Enums.PayStatus Status { get; set; }
        public Enums.EditionType Type { get; set; }
        public Enums.Currency Currency { get; set; }
    }
}
