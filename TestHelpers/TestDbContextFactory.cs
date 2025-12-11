using System;
using Microsoft.EntityFrameworkCore;
using VanDongNguyen_FinalExam.Data;

namespace VanDongNguyen_FinalExam.Tests.TestHelpers
{
    public static class TestDbContextFactory
    {
        public static ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDb_" + Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
