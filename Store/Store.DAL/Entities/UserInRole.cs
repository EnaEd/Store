namespace Store.DAL.Entities
{
    public class UserInRole : BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
