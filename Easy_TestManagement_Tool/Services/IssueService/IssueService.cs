using Easy_TestManagement_Tool.Data;

namespace Easy_TestManagement_Tool.Services.IssueService
{
    public class IssueService : IIssueService
    {
        private readonly DataContext _context;

        public IssueService(DataContext context)
        {
            _context = context;
        }

        public async Task<Issue> GetIssueById(int id)
        {
            return await _context.TB_Issue.FindAsync(id);
        }

        public async Task<List<Issue>> GetAllIssues()
        {
            return await _context.TB_Issue.ToListAsync();
        }

        public async Task<int> CreateIssue(Issue issue)
        {
            _context.TB_Issue.Add(issue);
            await _context.SaveChangesAsync();
            return issue.Id;
        }

        public async Task UpdateIssue(Issue issue)
        {
            _context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIssue(int id)
        {
            var issue = await _context.TB_Issue.FindAsync(id);
            if (issue != null)
            {
                _context.TB_Issue.Remove(issue);
                await _context.SaveChangesAsync();
            }
        }
    }
}
