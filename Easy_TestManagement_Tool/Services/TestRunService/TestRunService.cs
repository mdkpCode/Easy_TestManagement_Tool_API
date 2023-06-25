using Easy_TestManagement_Tool.Data;

namespace Easy_TestManagement_Tool.Services.TestRunService
{
    public class TestRunService : ITestRunService
    {
        private readonly DataContext context;

        public TestRunService(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<TestRun>> CreateTestRun(TestRun testRun)
        {
            context.TB_TestRuns.Add(testRun);
            await context.SaveChangesAsync();

            return await context.TB_TestRuns.ToListAsync();

        }

        public Task<TestRun> DeleteTestRun(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TestRun>> GetTestRuns()
        {
            var testRuns = await context.TB_TestRuns.ToListAsync();

            if (testRuns == null)
                return null;

            return testRuns;
        }

        public Task<List<TestRun>> UpdateTestRun(int id, TestRun request)
        {
            throw new NotImplementedException();
        }


    }
}
