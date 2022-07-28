using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using StaffScheduler.Core.Domain;
using StaffScheduler.Core.Domain.Extensions;
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
        [Fact]
        public void ShouldGetOnlySchedulesInRange()
        {
            var schedules = new List<Schedule>()
            {
                new Schedule(11, new DateTime(2022, 5, 11), 5),
                new Schedule(11, new DateTime(2022, 6, 2), 10),
                new Schedule(11, new DateTime(2022, 7, 17), 24),
                new Schedule(11, new DateTime(2022, 8, 9), 15),
                new Schedule(11, new DateTime(2022, 9, 15), 8),
                new Schedule(11, new DateTime(2022, 10, 22), 7),
            };

            var dateRange = new DateTime(2022, 10, 22).Within(3); 
            
            //should return schedule with the last 3 months of the last date
            var filteredSchedule = schedules.Where(s => s.EndsOn >= dateRange).ToList();
            
            filteredSchedule.Count.ShouldBe(3);
            

        }
    }
}
