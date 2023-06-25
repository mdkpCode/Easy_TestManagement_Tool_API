using Easy_TestManagement_Tool.Enums;

namespace Easy_TestManagement_Tool.Models
{
    public class TestRun
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<TestCaseOnTestRun> TestCases { get; set; }
        public TestRunStatusEnum StatusId { get; set; }

        public TestRun()
        {
            TestCases = new List<TestCaseOnTestRun>();
        }

    }
}
