using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Shouldly;
using StaffScheduler.Core.Domain;
using Xunit;

namespace StaffScheduler.Tests.CoreTest.Domain
{
    public class StaffTest
    {
        [Fact]
        public void ShouldCreateStaffUser()
        {
            const string firstName = "John";
            const string lastName = "Doe";

            var user = new IdentityUser()
            {
                UserName = "JohnDoe",
                Email = "doe@example.com"
            };
            var staff = new Staff(user, firstName, lastName);

            staff.FirstName.ShouldBe(firstName);
            staff.LastName.ShouldBe(lastName);
            staff.User.UserName.ShouldBe("JohnDoe");
            staff.User.Email.ShouldBe("doe@example.com");
        }

        [Fact]
        public void ShouldGetAccumulatedWorkHours()
        {
            var schedules = new List<Schedule>
            {
                new (234, DateTime.Today, DateTime.Today.AddHours(5)),
                new (268, DateTime.Today.AddDays(1), DateTime.Today.AddDays(1).AddHours(10)),
                new (268, DateTime.Today.AddDays(2), DateTime.Today.AddDays(2).AddHours(3))
            };
            var user = new IdentityUser()
            {
                UserName = "Derick.Moe",
                Email = "moe@example.com"
            };
            var staff = new Staff(user, "Derick", "Moe")
            {
                Schedules = schedules
            };

            staff.AccumulatedHours().ShouldBe(18);
        }
    }
}

