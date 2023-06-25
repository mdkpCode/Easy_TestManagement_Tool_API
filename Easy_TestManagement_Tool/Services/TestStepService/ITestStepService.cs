namespace Easy_TestManagement_Tool.Services.TestStepService
{
    public interface ITestStepService
    {
        Task<List<TestStep>?> GetTestCaseSteps(int testCaseId);

        Task<List<TestStep>?> GetSteps();

        Task<TestStep>? DeleteStep(int testCaseId);

        Task<List<TestStep>?> UpdateStep(int id, TestStep request);
    }








}
