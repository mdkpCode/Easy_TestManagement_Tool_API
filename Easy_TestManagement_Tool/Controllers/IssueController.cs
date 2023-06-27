using Easy_TestManagement_Tool.Services.IssueService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Easy_TestManagement_Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;

        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> GetIssueById(int id)
        {
            var issue = await _issueService.GetIssueById(id);
            if (issue == null)
            {
                return NotFound("Issue not found");
            }
            return issue;
        }

        [HttpGet]
        public async Task<ActionResult<List<Issue>>> GetAllIssues()
        {
            var issues = await _issueService.GetAllIssues();
            return issues;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateIssue(Issue issue)
        {
            var createdIssueId = await _issueService.CreateIssue(issue);
            return CreatedAtAction(nameof(GetIssueById), new { id = createdIssueId }, createdIssueId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIssue(int id, Issue issue)
        {
            if (id != issue.Id)
            {
                return BadRequest("Invalid issue ID");
            }

            await _issueService.UpdateIssue(issue);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssue(int id)
        {
            await _issueService.DeleteIssue(id);
            return NoContent();
        }
    }
}
