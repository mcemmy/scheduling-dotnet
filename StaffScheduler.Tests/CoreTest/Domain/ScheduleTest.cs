using System;
using Shouldly;
using StaffScheduler.Core.Domain;
using Xunit;

namespace StaffScheduler.Tests.CoreTest.Domain
{
    public class ScheduleTest
    {
        [Fact]
        public void ShouldCreateSchedule()
        {
            var startDate = DateTime.Today;
            var endDate = DateTime.Today.AddDays(2);

            var schedule = new Schedule(startDate, 48);

            schedule.StartsOn.ShouldBe(startDate);
            schedule.EndsOn.ShouldBe(endDate);

        }

        [Fact]
        public void ShouldCreateScheduleWithEndDate()
        {
            var startDate = DateTime.Today;
            var endDate = DateTime.Today.AddHours(5);

            var schedule = new Schedule(1203, startDate, endDate);

            schedule.Id.ShouldBe(1203);
            schedule.StartsOn.ShouldBe(startDate);
            schedule.EndsOn.ShouldBe(endDate);
            schedule.DurationInHours.ShouldBe(5);

        }

        [Fact]
        public void ShouldCreateScheduleWithId()
        {
            var startDate = DateTime.Today;
            var endDate = DateTime.Today.AddHours(2);

            var schedule = new Schedule(45,startDate, 2);

            schedule.Id.ShouldBe(45);
            schedule.StartsOn.ShouldBe(startDate);
            schedule.EndsOn.ShouldBe(endDate);

        }
    }
}
