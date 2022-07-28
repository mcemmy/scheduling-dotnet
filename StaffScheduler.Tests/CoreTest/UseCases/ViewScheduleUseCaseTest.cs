using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using StaffScheduler.Core.Application.Interfaces;
using StaffScheduler.Core.Application.UseCases;
using StaffScheduler.Core.Application.UseCases.Schedule.ViewSchedule;
using Xunit;
using Schedule = StaffScheduler.Core.Domain.Schedule;

namespace StaffScheduler.Tests.CoreTest.UseCases
{
    public class ViewScheduleUseCaseTest
    {
        private readonly Mock<IScheduleRepository> _scheduleRepo;
        private readonly Mock<ILogger<ViewScheduleUseCase>> _logger;
        public ViewScheduleUseCaseTest()
        {
            _scheduleRepo = new Mock<IScheduleRepository>();
            _logger = new Mock<ILogger<ViewScheduleUseCase>>();
        }

        [Fact]
        public async Task ShouldRetrieveSchedule()
        {
            _scheduleRepo.Setup(x => x.GetByUserNameAsync(It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(SampleSchedule);

           
            var viewScheduleUseCase = new ViewScheduleUseCase(_scheduleRepo.Object, _logger.Object);

            var request = new ViewScheduleRequest()
            {
                UserName = "john.doe", WithinPeriodInMonths = 11
            };

            var result = await viewScheduleUseCase.Handle(request, CancellationToken.None);

            result.Schedules.Count.ShouldBe(1);
            result.UserName.ShouldBe("john.doe");
            result.Schedules[0].DurationInHours.ShouldBe(4);
            

        }

        [Fact]
        public void NotFoundExceptionShouldReturnMessage()
        {
            _scheduleRepo.Setup(x => x.GetByUserNameAsync(It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(new List<Schedule>());

            var viewScheduleUseCase = new ViewScheduleUseCase(_scheduleRepo.Object, _logger.Object);

            var request = new ViewScheduleRequest()
            {
                UserName = "mac.twin",
                WithinPeriodInMonths = 5
            };

            var response =  viewScheduleUseCase.Handle(request, CancellationToken.None).Result;
            
            response.Status.ShouldBe(Status.NotFound);
           
        }


        private static List<Schedule> SampleSchedule()
        {
            return
                new List<Schedule>()
                {
                    new (253, new DateTime(2022, 04, 11), 4)
                };

        }
    }
}
