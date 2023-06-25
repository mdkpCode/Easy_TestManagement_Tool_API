using Easy_TestManagement_Tool.Models;

namespace Easy_TestManagement_Tool.Services.TestCaseService
{
    public interface ITestCaseService
    {
        Task<List<TestCase>?> GetAllTestCases();

        Task<TestCase>? GetSingleTestCase(int id);

        Task<List<TestCase>?> AddTestCase(TestCase testCase);

        Task<List<TestCase>?> UpdateTestCase(int id, TestCase request);

        Task<List<TestCase>?> DeleteTestCase(int id);
    }

}
