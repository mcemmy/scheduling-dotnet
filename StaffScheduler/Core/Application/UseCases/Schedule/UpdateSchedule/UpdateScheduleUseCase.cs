using Azure;
using MediatR;
using StaffScheduler.Core.Application.Interfaces;

namespace StaffScheduler.Core.Application.UseCases.Schedule.UpdateSchedule
{
    public class UpdateScheduleUseCase : IRequestHandler<UpdateScheduleRequest, UpdateScheduleResponse>
    {
        private readonly IScheduleRepository _scheduleRepository;
        public UpdateScheduleUseCase(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        public async Task<UpdateScheduleResponse> Handle(UpdateScheduleRequest request, CancellationToken cancellationToken)
        {
            var editedSchedule = new Domain.Schedule(request.ScheduleId, request.NewStartTime, request.NewDurationInHours);

            await _scheduleRepository.UpdateAsync(editedSchedule);

            return new UpdateScheduleResponse(Status.Ok,Messages.Successful);
        }
    }
}
