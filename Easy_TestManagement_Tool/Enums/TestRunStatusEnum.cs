using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace Easy_TestManagement_Tool.Enums
{
    public enum TestRunStatusEnum
    {
        [EnumMember(Value = "Pending")]
        Pending = 1,

        [EnumMember(Value = "InProgress")]
        InProgress = 2,

        [EnumMember(Value = "Passed")]
        Passed = 3,

        [EnumMember(Value = "Failed")]
        Failed = 4
    }
}