
using Easy_TestManagement_Tool.Models.EnumModels;
using System.ComponentModel.DataAnnotations;

namespace Easy_TestManagement_Tool.Models
{
    public class TestCaseOnTestRun
    {
        [Key]
        public int Id { get; set; }
        public List<TestCase>? TestCase { get; set; }
        public TestStatusDictionary Status { get; set; }
    }
}