using Store.Shared.Enums;
using System;

namespace Store.BusinessLogicLayer.Models.Users
{
    public class UserProfileModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? LastActivity { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int CanceledOrdersCount { get; set; }
        public int OrdersCount { get; set; }
        public Enums.UserRole Role { get; set; }
    }
}
