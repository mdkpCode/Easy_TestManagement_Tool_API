namespace Easy_TestManagement_Tool.Services.ReportService;

public interface IReportService
{
    Task<byte[]> GenerateTestCasesReport(string title, string content);

    Task<byte[]> GenerateTestRunReport(string title, string content);
}
