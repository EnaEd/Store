using Microsoft.AspNetCore.Identity;

namespace Store.DataAccessLayer.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
