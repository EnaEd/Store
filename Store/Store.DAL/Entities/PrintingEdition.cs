namespace Store.DAL.Entities
{
    public class PrintingEdition : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public string Currency { get; set; }
        public int Type { get; set; }
    }
}
