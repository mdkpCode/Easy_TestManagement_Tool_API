using Easy_TestManagement_Tool.Services.ReportService;
using Easy_TestManagement_Tool.Services.TestRunService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Easy_TestManagement_Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService reportService;
        private readonly ITestRunService testRunService;

        public ReportController(IReportService reportService, ITestRunService testRunService)
        {
            this.reportService = reportService;
            this.testRunService = testRunService;
        }

        [HttpGet("TestCasesReport")]
        public async Task<IActionResult> GenerateTestCasesReport()
        {
            string title = "Tytuł raportu";
            string content = "Zawartość raportu";

            var testRuns = await testRunService.GetTestRuns();

            byte[] pdfBytes = await reportService.GenerateTestCasesReport(title, content);


            return File(pdfBytes, "application/pdf", "raport_testcases.pdf");
        }


        [HttpGet("TestRunsReport")]
        public async Task<IActionResult> GenerateTestRunsReport()
        {
            string title = "Tytuł raportu";
            string content = "Zawartość raportu";

            var testRuns = await testRunService.GetTestRuns();

            byte[] pdfBytes = await reportService.GenerateTestRunReport(title, content);


            return File(pdfBytes, "application/pdf", "raport_testruns.pdf");
        }
    }
}
