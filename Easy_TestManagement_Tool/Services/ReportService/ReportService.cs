using Easy_TestManagement_Tool.Data;
using Easy_TestManagement_Tool.Services.TestRunService;
using PdfSharpCore.Drawing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Easy_TestManagement_Tool.Services.ReportService
{
    public class ReportService : IReportService
    {
        private DataContext _context { get; }

        public ReportService(DataContext context)
        {
            _context = context;
        }

        public async Task<byte[]> GenerateTestCasesReport(string title, string content)
        {
            // Fetch data from db
            var testCases = _context.TB_TestCases.Include(TestCase => TestCase.Steps)
                                          .ToListAsync();

            // Generate report as pdf
            var pdfDocument = new PdfSharpCore.Pdf.PdfDocument();
            var pdfPage = pdfDocument.AddPage();
            var gfx = XGraphics.FromPdfPage(pdfPage);
            var font = new XFont("Arial", 12, XFontStyle.Bold);

            int yPos = 50;

            // Load logo
            var logoPath = Path.Combine("Assets", "ReportAssets", "logo-report.png");
            using (var logoStream = new MemoryStream(File.ReadAllBytes(logoPath)))
            using (var logoImage = Image.Load(logoStream))
            {
                var logoWidth = 250;
                var logoHeight = 250;

                logoImage.Mutate(x => x.Resize(new ResizeOptions { Size = new Size(logoWidth, logoHeight) }));

                var logoXPos = pdfPage.Width - logoWidth - 50;
                var logoYPos = -15;

                using (var memoryStream = new MemoryStream())
                {
                    logoImage.Save(memoryStream, new PngEncoder());

                    memoryStream.Position = 0;

                    gfx.DrawImage(XImage.FromStream(() => memoryStream), logoXPos, logoYPos);
                }
            }

            // Header
            gfx.DrawString("Report - List of all test cases:", font, XBrushes.Black, new XRect(50, 50, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            yPos += 100;

            // Draw test cases data
            foreach (var testCase in await testCases)
            {
                gfx.DrawLine(XPens.LightGray, 50, yPos, pdfPage.Width - 50, yPos);

                // ID
                gfx.DrawString($"ID: {testCase.Id}", font, XBrushes.Black, new XRect(50, yPos + 10, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPos += 30;

                // Name
                gfx.DrawString($"Name: {testCase.Name}", font, XBrushes.Black, new XRect(50, yPos, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPos += 20;

                // Description
                gfx.DrawString($"Description: {testCase.Description}", font, XBrushes.Black, new XRect(50, yPos, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPos += 20;

                // Precondition
                gfx.DrawString($"Precondition: {testCase.Precondition}", font, XBrushes.Black, new XRect(50, yPos, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPos += 20;

                // Steps
                foreach (var step in testCase.Steps)
                {
                    gfx.DrawString($"- {step.Description}", font, XBrushes.Black, new XRect(50, yPos, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    yPos += 20;
                }

                // Status
                gfx.DrawString($"Status: {testCase.Status}", font, XBrushes.Black, new XRect(50, yPos, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPos += 20;

                yPos += 20;
            }

            // Save report as pdf array
            using (var memoryStream = new MemoryStream())
            {
                pdfDocument.Save(memoryStream);
                return memoryStream.ToArray();
            }
        }
        public async Task<byte[]> GenerateTestRunReport(string title, string content)
        {
            // Fetch data from db
            var testRuns = await _context.TB_TestRuns.ToListAsync();

            // Generate report as pdf
            var pdfDocument = new PdfSharpCore.Pdf.PdfDocument();
            var pdfPage = pdfDocument.AddPage();
            var gfx = XGraphics.FromPdfPage(pdfPage);
            var font = new XFont("Arial", 12, XFontStyle.Bold);

            int yPos = 50;

            // Load logo
            var logoPath = Path.Combine("Assets", "ReportAssets", "logo-report.png");
            using (var logoStream = new MemoryStream(File.ReadAllBytes(logoPath)))
            using (var logoImage = Image.Load(logoStream))
            {
                var logoWidth = 250;
                var logoHeight = 250;

                logoImage.Mutate(x => x.Resize(new ResizeOptions { Size = new Size(logoWidth, logoHeight) }));

                var logoXPos = pdfPage.Width - logoWidth - 50;
                var logoYPos = -15;

                using (var memoryStream = new MemoryStream())
                {
                    logoImage.Save(memoryStream, new PngEncoder());

                    memoryStream.Position = 0;

                    gfx.DrawImage(XImage.FromStream(() => memoryStream), logoXPos, logoYPos);
                }
            }

            // Header
            gfx.DrawString("Report - List of all test runs:", font, XBrushes.Black, new XRect(50, 50, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            yPos += 100;

            // Draw test cases data
            foreach (var testRun in testRuns)
            {
                gfx.DrawLine(XPens.LightGray, 50, yPos, pdfPage.Width - 50, yPos);

                // ID
                gfx.DrawString($"ID: {testRun.Id}", font, XBrushes.Black, new XRect(50, yPos + 10, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPos += 30;

                // Name
                gfx.DrawString($"Name: {testRun.Name}", font, XBrushes.Black, new XRect(50, yPos, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPos += 20;

                // Precondition
                gfx.DrawString($"Precondition: {testRun.StatusId}", font, XBrushes.Black, new XRect(50, yPos, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPos += 20;
            }

            // Save report as pdf array
            using (var memoryStream = new MemoryStream())
            {
                pdfDocument.Save(memoryStream);
                return memoryStream.ToArray();
            }

            // Return null or empty byte array if testRuns is empty
            return null; // or return new byte[0];
        }
    }
}
