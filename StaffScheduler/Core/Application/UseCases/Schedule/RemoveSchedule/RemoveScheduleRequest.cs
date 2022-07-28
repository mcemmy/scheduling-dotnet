using MediatR;

namespace StaffScheduler.Core.Application.UseCases.Schedule.RemoveSchedule
{
    public class RemoveScheduleRequest :IRequest<RemoveScheduleResponse>
    {
        public int ScheduleId { get; set; }
    }
}
