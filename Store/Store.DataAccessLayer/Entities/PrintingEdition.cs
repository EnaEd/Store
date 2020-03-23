namespace Store.DataAccessLayer.Entities
{
    public class PrintingEdition : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Currency { get; set; }
    }
}
