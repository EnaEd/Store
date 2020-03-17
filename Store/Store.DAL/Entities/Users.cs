namespace Store.DAL.Entities
{
    public class Users : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
    }
}
