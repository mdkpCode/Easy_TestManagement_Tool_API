using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Easy_TestManagement_Tool.Data;
using Easy_TestManagement_Tool.Services.TestRunService;
using Microsoft.AspNetCore.Mvc;

namespace Easy_TestManagement_Tool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestRunController : ControllerBase
    {
        private readonly ITestRunService _testRunService;

        public TestRunController(ITestRunService testRunService)
        {
            _testRunService = testRunService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestRun>> GetSingleTestRun(int id)
        {
            var testRun = await _testRunService.GetSingleTestRun(id);

            if (testRun == null)
                return NotFound();

            return testRun;
        }

        [HttpGet]
        public async Task<ActionResult<List<TestRun>>> GetTestRuns()
        {
            var testRuns = await _testRunService.GetTestRuns();

            if (testRuns == null)
                return NotFound();

            return testRuns;
        }

        [HttpPost]
        public async Task<ActionResult<List<TestRun>>> CreateTestRun(TestRun testRun)
        {
            var createdTestRuns = await _testRunService.CreateTestRun(testRun);

            return createdTestRuns;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TestRun>> DeleteTestRun(int id)
        {
            var deletedTestRun = await _testRunService.DeleteTestRun(id);

            if (deletedTestRun == null)
                return NotFound();

            return deletedTestRun;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TestRun>>> UpdateTestRun(int id, TestRun request)
        {
            var updatedTestRuns = await _testRunService.UpdateTestRun(id, request);

            return updatedTestRuns;
        }
    }
}
