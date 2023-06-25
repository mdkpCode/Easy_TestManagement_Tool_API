using Easy_TestManagement_Tool.Data;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Easy_TestManagement_Tool.Services.TestStepService
{
    public class TestStepService : ITestStepService
    {
        private DataContext context { get; }

        public TestStepService(DataContext context)
        {
            this.context = context;
        }

        public async Task<TestStep> DeleteStep(int id)
        {
            var step = await context.TB_TestSteps.FirstOrDefaultAsync(x => x.Id == id);

            if (step == null)
                return null;

            context.Remove(step);
            await context.SaveChangesAsync();

            return step;
        }

        public async Task<List<TestStep>> GetTestCaseSteps(int testCaseId)
        {
            var testSteps = await context.TB_TestCases
                .SelectMany(tc => tc.Steps)
                .Where(TestCaseStep => TestCaseStep.Id == testCaseId)
                .ToListAsync();

            return testSteps;
        }

        public async Task<List<TestStep>?> UpdateStep(int id, TestStep request)
        {
            var step = await context.TB_TestSteps.FindAsync(id);

            if (step == null)
                return null;

            step.Description = request.Description;
            step.ExpectedResults = request.ExpectedResults;
            await context.SaveChangesAsync();

            return await context.TB_TestSteps.ToListAsync();
        }

        public async Task<List<TestStep>> GetSteps()
        {
            var steps = await context.TB_TestSteps.ToListAsync();

            if (steps == null)
                return null;

            return steps;
        }


    }
}
