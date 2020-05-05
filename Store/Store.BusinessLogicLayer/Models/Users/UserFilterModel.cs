using Store.BusinessLogicLayer.Models.Base;
using Store.Shared.Enums;
using System;

namespace Store.BusinessLogicLayer.Models.Users
{
    public class UserFilterModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? LastActivity { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public Enums.UserRole? Role { get; set; }
    }
}
