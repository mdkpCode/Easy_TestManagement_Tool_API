
using Easy_TestManagement_Tool.Models.EnumModels;

namespace Easy_TestManagement_Tool.Models
{
    public class TestCaseOnTestRun
    {
        public int Id { get; set; }
        public List<TestCase>? TestCase { get; set; }
        public TestStatusDictionary Status { get; set; }
    }
}