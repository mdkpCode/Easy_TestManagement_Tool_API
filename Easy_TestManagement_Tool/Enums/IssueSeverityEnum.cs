using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace Easy_TestManagement_Tool.Enums
{
    public enum IssueSeverityEnum
    {
        [EnumMember(Value = "Low")]
        Low,

        [EnumMember(Value = "Medium")]
        Medium,

        [EnumMember(Value = "High")]
        High,

        [EnumMember(Value = "Critical")]
        Critical
    }
}
