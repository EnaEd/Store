namespace Store.BusinessLogicLayer.Models.PrintingEdition
{
    public class PayRequestModel
    {
        public string CardNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string CVCCode { get; set; }
        public decimal Amount { get; set; }
        public PrintingEditionModel Edition { get; set; }
        public int? Count { get; set; }
    }
}
