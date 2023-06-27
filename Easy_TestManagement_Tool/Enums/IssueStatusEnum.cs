using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace Easy_TestManagement_Tool.Enums
{
    public enum IssueStatusEnum
    {
        [EnumMember(Value = "Opened")]
        Low,

        [EnumMember(Value = "Closed")]
        Medium,
    }
}
