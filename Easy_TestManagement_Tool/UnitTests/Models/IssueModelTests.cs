using System;
using System.ComponentModel.DataAnnotations;
using Easy_TestManagement_Tool.Models;
using NUnit.Framework;

namespace Easy_TestManagement_Tool.Tests.Models
{
    [TestFixture]
    public class IssueTests
    {
        [Test]
        public void Issue_Validation_ValidModel_ShouldPass()
        {
            // Arrange
            var issue = new Issue
            {
                Id = 1,
                Title = "Sample Issue",
                Description = "Sample description",
                CreatedDate = DateTime.Now,
                Severity = IssueSeverityEnum.Low,
                Status = IssueStatusEnum.Medium
            };

            // Act
            var validationContext = new ValidationContext(issue, null, null);
            var validationResult = Validator.TryValidateObject(issue, validationContext, null, true);

            // Assert
            Assert.IsTrue(validationResult);
        }

        [Test]
        public void Issue_Validation_MissingRequiredFields_ShouldFail()
        {
            // Arrange
            var issue = new Issue();

            // Act
            var validationContext = new ValidationContext(issue, null, null);
            var validationResult = Validator.TryValidateObject(issue, validationContext, null, true);

            // Assert
            Assert.IsFalse(validationResult);
        }

        [Test]
        public void Issue_Validation_InvalidSeverityValue_ShouldFail()
        {
            // Arrange
            var issue = new Issue
            {
                Id = 1,
                Title = "Sample Issue",
                Description = "Sample description",
                CreatedDate = DateTime.Now,
                Severity = (IssueSeverityEnum)100, // Invalid value
                Status = IssueStatusEnum.Medium
            };

            // Act
            var validationContext = new ValidationContext(issue, null, null);
            var validationResult = Validator.TryValidateObject(issue, validationContext, null, true);

            // Assert
            Assert.IsFalse(validationResult);
        }

        [Test]
        public void Issue_Validation_InvalidStatusValue_ShouldFail()
        {
            // Arrange
            var issue = new Issue
            {
                Id = 1,
                Title = "Sample Issue",
                Description = "Sample description",
                CreatedDate = DateTime.Now,
                Severity = IssueSeverityEnum.Low,
                Status = (IssueStatusEnum)100 // Invalid value
            };

            // Act
            var validationContext = new ValidationContext(issue, null, null);
            var validationResult = Validator.TryValidateObject(issue, validationContext, null, true);

            // Assert
            Assert.IsFalse(validationResult);
        }
    }
}