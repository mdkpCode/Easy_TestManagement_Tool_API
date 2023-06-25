using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace Easy_TestManagement_Tool.Enums
{
    public enum TestStatusEnum
    {
        [EnumMember(Value = "Enabled")]
        Enabled = 1,

        [EnumMember(Value = "Deprecated")]
        Deprecated = 2,
    }
}