using Easy_TestManagement_Tool.Services.TestEnvironmentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Easy_TestManagement_Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestEnvironmentController : ControllerBase
    {
        private readonly ITestEnvironmentService _testEnvironmentService;

        public TestEnvironmentController(ITestEnvironmentService testEnvironmentService)
        {
            _testEnvironmentService = testEnvironmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TestEnvironment>>> GetAllTestEnvironments()
        {
            var testEnvironments = await _testEnvironmentService.GetAllTestEnvironments();
            return Ok(testEnvironments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestEnvironment>> GetTestEnvironmentById(int id)
        {
            var testEnvironment = await _testEnvironmentService.GetTestEnvironmentById(id);
            if (testEnvironment == null)
                return NotFound();

            return Ok(testEnvironment);
        }

        [HttpPost]
        public async Task<ActionResult<TestEnvironment>> CreateTestEnvironment(TestEnvironment testEnvironment)
        {
            var createdEnvironment = await _testEnvironmentService.CreateTestEnvironment(testEnvironment);
            return CreatedAtAction(nameof(GetTestEnvironmentById), new { id = createdEnvironment.Id }, createdEnvironment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TestEnvironment>> UpdateTestEnvironment(int id, TestEnvironment testEnvironment)
        {
            var updatedEnvironment = await _testEnvironmentService.UpdateTestEnvironment(id, testEnvironment);
            if (updatedEnvironment == null)
                return NotFound();

            return Ok(updatedEnvironment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTestEnvironment(int id)
        {
            var result = await _testEnvironmentService.DeleteTestEnvironment(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
