using System.Collections.Generic;
using System.Threading.Tasks;
using Easy_TestManagement_Tool.Controllers;
using Easy_TestManagement_Tool.Models;
using Easy_TestManagement_Tool.Services.TestCaseService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Easy_TestManagement_Tool.Tests.Controllers
{
    [TestFixture]
    public class TestCaseControllerTests
    {
        private Mock<ITestCaseService> _testCaseServiceMock;
        private TestCaseController _testCaseController;

        [SetUp]
        public void Setup()
        {
            _testCaseServiceMock = new Mock<ITestCaseService>();
            _testCaseController = new TestCaseController(_testCaseServiceMock.Object);
        }

        [Test]
        public async Task GetSingleTestCase_ExistingId_ReturnsTestCase()
        {
            // Arrange
            int testCaseId = 1;
            var expectedTestCase = new TestCase { Id = testCaseId, Name = "Test Case 1" };
            _testCaseServiceMock.Setup(x => x.GetSingleTestCase(testCaseId)).ReturnsAsync(expectedTestCase);

            // Act
            var result = await _testCaseController.GetSingleTestCase(testCaseId);

            // Assert
            var actionResult = result.Result as OkObjectResult;
            var actualTestCase = actionResult.Value as TestCase;

            Assert.IsNotNull(actualTestCase);
            Assert.AreEqual(expectedTestCase.Id, actualTestCase.Id);
            Assert.AreEqual(expectedTestCase.Name, actualTestCase.Name);
        }

        [Test]
        public async Task GetSingleTestCase_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int testCaseId = 1;
            _testCaseServiceMock.Setup(x => x.GetSingleTestCase(testCaseId)).ReturnsAsync((TestCase)null);

            // Act
            var result = await _testCaseController.GetSingleTestCase(testCaseId);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
        }
    }
}