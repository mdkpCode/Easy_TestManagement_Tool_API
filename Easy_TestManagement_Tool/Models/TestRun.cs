using Easy_TestManagement_Tool.Enums;
using System.ComponentModel.DataAnnotations;

namespace Easy_TestManagement_Tool.Models
{
    public class TestRun
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<TestCaseOnTestRun> TestCases { get; set; }

        public TestRunStatusEnum StatusId { get; set; }

        public TestRun()
        {
            TestCases = new List<TestCaseOnTestRun>();
        }

    }
}
