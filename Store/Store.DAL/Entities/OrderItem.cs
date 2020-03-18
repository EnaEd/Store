namespace Store.DAL.Entities
{
    public class OrderItem : BaseEntity
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int PrintingEditionId { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
    }
}
