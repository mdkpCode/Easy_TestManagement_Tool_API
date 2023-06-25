using Easy_TestManagement_Tool.Services.TestCaseService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Easy_TestManagement_Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCaseController : ControllerBase
    {
        public ITestCaseService _testCaseService;

        public TestCaseController(ITestCaseService testCaseService)
        {
            _testCaseService = testCaseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TestCase>>> GetAllTestCases()
        {
            return await _testCaseService.GetAllTestCases();
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TestCase>>> GetSingleTestCase(int id)
        {
            var results = await _testCaseService.GetSingleTestCase(id);
            if (results is null)
                return NotFound($"Tast case with id: {id} not found in database.");
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult<List<TestCase>>> AddTestCase(TestCase testCase)
        {
            var results = await _testCaseService.AddTestCase(testCase);
            return Ok(results);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TestCase>>> UpdateTestCase(int id, TestCase request)
        {
            var results = await _testCaseService.UpdateTestCase(id, request);
            if (results is null)
                return NotFound($"Tast case with id: {id} not found in database.");

            return Ok(results);
        }

            [HttpDelete("{id}")]
        public async Task<ActionResult<List<TestCase>>> DeleteTestCase(int id)
        {
            var results = await _testCaseService.DeleteTestCase(id);
            if (results is null)
                return NotFound($"Tast case with id: {id} not found in database.");

            return Ok($"Tast case with id: {id} deleted.");
        }
    }
}
