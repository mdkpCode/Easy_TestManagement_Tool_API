using Easy_TestManagement_Tool.Data;

namespace Easy_TestManagement_Tool.Services.TestEnvironmentService
{
    public class TestEnvironmentService : ITestEnvironmentService
    {
        private readonly DataContext _context;

        public TestEnvironmentService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<TestEnvironment>> GetAllTestEnvironments()
        {
            return await _context.TB_TestEnvironment.ToListAsync();
        }

        public async Task<TestEnvironment> GetTestEnvironmentById(int id)
        {
            return await _context.TB_TestEnvironment.FindAsync(id);
        }

        public async Task<TestEnvironment> CreateTestEnvironment(TestEnvironment testEnvironment)
        {
            _context.TB_TestEnvironment.Add(testEnvironment);
            await _context.SaveChangesAsync();
            return testEnvironment;
        }

        public async Task<TestEnvironment> UpdateTestEnvironment(int id, TestEnvironment testEnvironment)
        {
            var existingEnvironment = await _context.TB_TestEnvironment.FindAsync(id);
            if (existingEnvironment == null)
                return null;

            existingEnvironment.Name = testEnvironment.Name;
            existingEnvironment.Url = testEnvironment.Url;
            existingEnvironment.Description = testEnvironment.Description;
            existingEnvironment.Configuration = testEnvironment.Configuration;

            await _context.SaveChangesAsync();
            return existingEnvironment;
        }

        public async Task<bool> DeleteTestEnvironment(int id)
        {
            var testEnvironment = await _context.TB_TestEnvironment.FindAsync(id);
            if (testEnvironment == null)
                return false;

            _context.TB_TestEnvironment.Remove(testEnvironment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
