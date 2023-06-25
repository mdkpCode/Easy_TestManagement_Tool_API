namespace Easy_TestManagement_Tool.Services.TestRunService
{
    public interface ITestRunService
    {
        Task<List<TestRun>> GetTestRuns();

        Task<TestRun> DeleteTestRun(int id);

        Task<List<TestRun>> UpdateTestRun(int id, TestRun request);

        Task<List<TestRun>> CreateTestRun(TestRun testRun);
    }
}
