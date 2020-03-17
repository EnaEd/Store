namespace Store.DAL.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsRemoved { get; set; }
    }
}
