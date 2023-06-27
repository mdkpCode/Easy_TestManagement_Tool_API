namespace Easy_TestManagement_Tool.Services.IssueService
{
    public interface IIssueService
    {
        Task<Issue> GetIssueById(int id);
        Task<List<Issue>> GetAllIssues();
        Task<int> CreateIssue(Issue issue);
        Task UpdateIssue(Issue issue);
        Task DeleteIssue(int id);
    }
}
