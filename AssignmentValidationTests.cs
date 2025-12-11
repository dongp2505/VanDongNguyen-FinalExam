using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VanDongNguyen_FinalExam.Models;

namespace VanDongNguyen_FinalExam.Tests
{
    [TestClass]
    public class AssignmentValidationTests
    {
        [TestMethod]
        public void Assignment_Title_IsRequired()
        {
            // Arrange: create Assignment with no Title
            var assignment = new Assignment
            {
                Title = null,        // should trigger [Required]
                DueDate = DateTime.Now,
                Grade = 85
            };

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(assignment, null, null);

            // Act
            bool isValid = Validator.TryValidateObject(
                assignment,
                context,
                validationResults,
                validateAllProperties: true);

            // Assert: model should NOT be valid and Title should be in error list
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.MemberNames.Contains("Title")));
        }
    }
}
