using System.Text.Json.Serialization;

namespace Easy_TestManagement_Tool.Models.EnumModels
{
    public class TestStatusDictionary
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
