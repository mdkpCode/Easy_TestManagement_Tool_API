using System.Text.Json.Serialization;

namespace Easy_TestManagement_Tool.Models.EnumModels
{
    public class TestRunStatusDictionary
    {
        [JsonIgnore]
        public  long Id { get; set; }
        public string Status { get; set; } =string.Empty;
    }
}
    