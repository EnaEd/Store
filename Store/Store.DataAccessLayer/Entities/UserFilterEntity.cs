
using System;
using static Store.Shared.Enums.Enums;

namespace Store.DataAccessLayer.Entities
{
    public class UserFilterEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? LastActivity { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public UserRole? Role { get; set; }
    }
}
