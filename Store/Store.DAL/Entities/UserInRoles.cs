namespace Store.DAL.Entities
{
    public class UserInRoles : BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
