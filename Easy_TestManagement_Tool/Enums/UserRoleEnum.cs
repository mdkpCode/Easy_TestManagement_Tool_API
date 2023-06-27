using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace Easy_TestManagement_Tool.Enums
{
    public enum UserRoleEnum
    {
        [EnumMember(Value = "Admin")]
        Admin,

        [EnumMember(Value = "User")]
        User,
    }
}
