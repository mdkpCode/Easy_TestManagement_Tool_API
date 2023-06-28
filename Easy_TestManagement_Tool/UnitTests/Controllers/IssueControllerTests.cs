using System.Collections.Generic;
using System.Threading.Tasks;
using Easy_TestManagement_Tool.Controllers;
using Easy_TestManagement_Tool.Models;
using Easy_TestManagement_Tool.Services.IssueService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Easy_TestManagement_Tool.Tests.Controllers
{
    [TestFixture]
    public class IssueControllerTests
    {
        private Mock<IIssueService> _issueServiceMock;
        private IssueController _issueController;

        [SetUp]
        public void SetUp()
        {
            _issueServiceMock = new Mock<IIssueService>();
            _issueController = new IssueController(_issueServiceMock.Object);
        }

        [Test]
        public async Task GetIssueById_ReturnsNotFound_WhenIssueDoesNotExist()
        {
            // Arrange
            int issueId = 1;
            _issueServiceMock.Setup(x => x.GetIssueById(issueId)).ReturnsAsync(null as Issue);

            // Act
            var result = await _issueController.GetIssueById(issueId);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
        }


        [Test]
        public async Task CreateIssue_ReturnsCreatedResponseWithIssueId()
        {
            // Arrange
            var issue = new Issue { Title = "New Issue" };
            int createdIssueId = 1;
            _issueServiceMock.Setup(x => x.CreateIssue(issue)).ReturnsAsync(createdIssueId);

            // Act
            var result = await _issueController.CreateIssue(issue);

            // Assert
            var actionResult = result as ActionResult<int>;
            var createdAtActionResult = actionResult.Result as CreatedAtActionResult;

            Assert.AreEqual(nameof(IssueController.GetIssueById), createdAtActionResult.ActionName);
            Assert.AreEqual(createdIssueId, createdAtActionResult.RouteValues["id"]);
            Assert.AreEqual(createdIssueId, createdAtActionResult.Value);
        }

        [Test]
        public async Task UpdateIssue_ReturnsNoContentResult_WhenIssueIsUpdated()
        {
            // Arrange
            int issueId = 1;
            var issue = new Issue { Id = issueId, Title = "Updated Issue" };

            // Act
            var result = await _issueController.UpdateIssue(issueId, issue);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public async Task UpdateIssue_ReturnsBadRequest_WhenIssueIdDoesNotMatch()
        {
            // Arrange
            int issueId = 1;
            var issue = new Issue { Id = 2, Title = "Updated Issue" };

            // Act
            var result = await _issueController.UpdateIssue(issueId, issue);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task DeleteIssue_ReturnsNoContentResult_WhenIssueIsDeleted()
        {
            // Arrange
            int issueId = 1;

            // Act
            var result = await _issueController.DeleteIssue(issueId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }
    }
}
