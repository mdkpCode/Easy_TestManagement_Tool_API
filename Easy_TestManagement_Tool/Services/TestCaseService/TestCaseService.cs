using Easy_TestManagement_Tool.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Easy_TestManagement_Tool.Services.TestCaseService
{
    public class TestCaseService : ITestCaseService
    {
        private readonly DataContext context;

        public TestCaseService(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<TestCase>?> AddTestCase(TestCase testCase)
        {
            context.TB_TestCases.Add(testCase);
            await context.SaveChangesAsync();
            return await context.TB_TestCases.ToListAsync();
        }

        public async Task<List<TestCase>?> DeleteTestCase(int id)
        {
            var testCase = await context.TB_TestCases.Include(tc => tc.Steps).FirstOrDefaultAsync(tc => tc.Id == id);

            if (testCase is null)
                return null;

            context.RemoveRange(testCase.Steps); //Remove related steps
            context.Remove(testCase); //Remove test case
            await context.SaveChangesAsync();

            return await context.TB_TestCases.ToListAsync();
        }

        public async Task<List<TestCase>?> GetAllTestCases()
        {
            return await context.TB_TestCases.Include(TestCase => TestCase.Steps)
                                          .ToListAsync();
        }


        public async Task<TestCase>? GetSingleTestCase(int id)
        {
            var testCase = await context.TB_TestCases.Include(tc => tc.Steps)
                                                  .SingleOrDefaultAsync(tc => tc.Id == id);
            if (testCase is null)
                return null;
            return testCase;
        }

        public async Task<List<TestCase>?> UpdateTestCase(int id, TestCase request)
        {
            var testCase = await context.TB_TestCases.FindAsync(id);
            if (testCase is null)
                return null;

            testCase.Name = request.Name;
            testCase.Description = request.Description;
            testCase.Steps = request.Steps;
            testCase.IsActive = request.IsActive;
            testCase.Status = request.Status;
            testCase.Precondition = request.Precondition;

            return await context.TB_TestCases.ToListAsync();
        }
    }
}
