namespace Store.BusinessLogicLayer.Models.Config
{
    public class StripeConfig
    {
        public string ApiPublishKey { get; set; }
        public string ApiSecretKey { get; set; }
        public string DefaultPaymentTypes { get; set; }
    }
}
