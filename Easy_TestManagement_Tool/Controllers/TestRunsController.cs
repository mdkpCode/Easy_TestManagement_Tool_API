﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Easy_TestManagement_Tool.Data;
using Easy_TestManagement_Tool.Models;
using Easy_TestManagement_Tool.Services.TestRunService;

namespace Easy_TestManagement_Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestRunsController : ControllerBase
    {
        private readonly ITestRunService _testRunService;

        public TestRunsController(ITestRunService testRunService)
        {
            _testRunService = testRunService;
        }

        // GET: api/TestRuns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestRun>>> GetTestRuns()
        {
            var testRuns = await _testRunService.GetTestRuns();

            if (testRuns == null)
            {
                return NotFound();
            }
            return testRuns;
        }

        // GET: api/TestRuns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestRun>> GetTestRun(int id)
        {
            var testRuns = _testRunService.GetSingleTestRun(id);

            if (testRuns == null)
            {
                return NotFound();
            }
            return await testRuns; ;


        }

        /*

                // PUT: api/TestRuns/5
                // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
                [HttpPut("{id}")]
                public async Task<IActionResult> PutTestRun(int id, TestRun testRun)
                {
                    if (id != testRun.Id)
                    {
                        return BadRequest();
                    }

                    _context.Entry(testRun).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TestRunExists(id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    return NoContent();
                }

                // POST: api/TestRuns
                // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
                [HttpPost]
                public async Task<ActionResult<TestRun>> PostTestRun(TestRun testRun)
                {
                  if (_context.TB_TestRuns == null)
                  {
                      return Problem("Entity set 'DataContext.TB_TestRuns'  is null.");
                  }
                    _context.TB_TestRuns.Add(testRun);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetTestRun", new { id = testRun.Id }, testRun);
                }

                // DELETE: api/TestRuns/5
                [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteTestRun(int id)
                {
                    if (_context.TB_TestRuns == null)
                    {
                        return NotFound();
                    }
                    var testRun = await _context.TB_TestRuns.FindAsync(id);
                    if (testRun == null)
                    {
                        return NotFound();
                    }

                    _context.TB_TestRuns.Remove(testRun);
                    await _context.SaveChangesAsync();

                    return NoContent();
                }

                private bool TestRunExists(int id)
                {
                    return (_context.TB_TestRuns?.Any(e => e.Id == id)).GetValueOrDefault();
                }*/
    }
}
