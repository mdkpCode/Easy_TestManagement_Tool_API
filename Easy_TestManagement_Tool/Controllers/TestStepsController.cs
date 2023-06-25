using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Easy_TestManagement_Tool.Data;
using Easy_TestManagement_Tool.Models;
using Easy_TestManagement_Tool.Services.TestStepService;

namespace Easy_TestManagement_Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestStepsController : ControllerBase
    {
        /*
        Task<List<TestStep>> GetSteps(int testCaseId);

        Task<TestStep> DeleteStep(int testCaseId);

        Task<List<TestCase>> UpdateStep(int testCaseId, TestStep request);
         */

        private readonly ITestStepService _testStepService;

        public TestStepsController(ITestStepService testStepService)
        {
            _testStepService = testStepService;
        }

        // GET: api/TestSteps
        [HttpGet("{testCaseId}")]
        public async Task<ActionResult<List<TestStep>>> GetTestSteps(int testCaseId)
        {
            var testSteps = await _testStepService.GetTestCaseSteps(testCaseId);
            if (testSteps == null)
                return NotFound($"No steps founded for test case id: {testCaseId}");

            return Ok(testSteps);
        }

        // DELETE: api/TestSteps
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestStep>> DeleteStep(int id)
        {
            var testStep = await _testStepService.DeleteStep(id);
            if (testStep == null)
                return NotFound($"Step with given id: {id} not found on database");

            return Ok($"Step with given id: {id} deleted from database.");
        }

        //PUT: api/TestSteps
        [HttpPut("{id}")]
        public async Task<ActionResult<TestStep>> UpdateStep(int id, TestStep request)
        {
            var step = await _testStepService.UpdateStep(id, request);

            if (step == null)
                return BadRequest($"Test step with given {id} not found on database");

            return Ok($"Step with given id: {id} successfuly updated on database");
        }
    }
}
