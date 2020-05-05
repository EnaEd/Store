using System.Runtime.Serialization;

namespace Store.Shared.Enums
{
    public partial class Enums
    {

        public enum UserRole
        {
            [EnumMember(Value = "None")]
            None = 0,
            [EnumMember(Value = "Admin")]
            Admin = 1,
            [EnumMember(Value = "Client")]
            Client = 2
        }
    }
}
