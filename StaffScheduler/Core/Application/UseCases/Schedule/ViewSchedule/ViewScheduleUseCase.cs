using MediatR;
using StaffScheduler.Core.Application.Exceptions;
using StaffScheduler.Core.Application.Interfaces;

namespace StaffScheduler.Core.Application.UseCases.Schedule.ViewSchedule
{

    public class ViewScheduleUseCase : IRequestHandler<ViewScheduleRequest, ViewScheduleResponse>
    {

        private readonly IScheduleRepository _scheduleRepository;
        public ViewScheduleUseCase(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<ViewScheduleResponse> Handle(ViewScheduleRequest request, CancellationToken cancellationToken)
        {

            var schedules = await _scheduleRepository.GetByUserNameAsync(request.UserName, request.WithinPeriodInMonths);

            if (schedules == null || !schedules.Any())
                throw new RecordNotFoundException(ExceptionMessages.ScheduleRecordNotFound);

            return GetResponse(request.UserName, schedules);
        }

        private static ViewScheduleResponse GetResponse(string username, IEnumerable<Domain.Schedule> schedules)
        {
            var staffSchedules = schedules
                .Select(item => new Schedule(item.Id, item.StartsOn, item.EndsOn, item.DurationInHours))
                .ToList();

            return new ViewScheduleResponse(Status.Ok, username, staffSchedules);
        }

    }
}
