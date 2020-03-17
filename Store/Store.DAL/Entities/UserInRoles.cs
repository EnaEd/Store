using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DAL.Entities
{
    public class UserInRoles:BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
