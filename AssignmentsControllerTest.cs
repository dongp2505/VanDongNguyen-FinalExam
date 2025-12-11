using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VanDongNguyen_FinalExam.Controllers;
using VanDongNguyen_FinalExam.Data;
using VanDongNguyen_FinalExam.Models;
using VanDongNguyen_FinalExam.Tests.TestHelpers;

namespace VanDongNguyen_FinalExam.Tests
{
    [TestClass]
    public class AssignmentsControllerTests
    {
        [TestMethod]
        public async Task Index_ReturnsViewResult_WithListOfAssignments()
        {
            // Arrange
            using var context = TestDbContextFactory.CreateContext();

            context.Assignments.Add(new Assignment
            {
                Title = "A1",
                Grade = 80,
                DueDate = System.DateTime.Now
            });

            context.Assignments.Add(new Assignment
            {
                Title = "A2",
                Grade = 90,
                DueDate = System.DateTime.Now.AddDays(1)
            });

            await context.SaveChangesAsync();

            // Mock UserManager (needed for AssignmentsController constructor)
            var store = new Mock<IUserStore<IdentityUser>>();
            var userManager = new Mock<UserManager<IdentityUser>>(
                store.Object, null, null, null, null, null, null, null, null);

            var controller = new AssignmentsController(context, userManager.Object);

            // Act
            var result = await controller.Index();
            var viewResult = result as ViewResult;

            // Assert
            Assert.IsNotNull(viewResult);
            var model = viewResult.Model as IEnumerable<Assignment>;
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count());
        }
    }
}
