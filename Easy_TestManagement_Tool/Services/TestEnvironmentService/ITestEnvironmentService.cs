namespace Easy_TestManagement_Tool.Services.TestEnvironmentService;

public interface ITestEnvironmentService
{
    Task<List<TestEnvironment>> GetAllTestEnvironments();
    Task<TestEnvironment> GetTestEnvironmentById(int id);
    Task<TestEnvironment> CreateTestEnvironment(TestEnvironment testEnvironment);
    Task<TestEnvironment> UpdateTestEnvironment(int id, TestEnvironment testEnvironment);
    Task<bool> DeleteTestEnvironment(int id);
}
