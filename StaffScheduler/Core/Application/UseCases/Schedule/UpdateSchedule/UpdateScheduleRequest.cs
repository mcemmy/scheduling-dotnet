using MediatR;

namespace StaffScheduler.Core.Application.UseCases.Schedule.UpdateSchedule
{
    public class UpdateScheduleRequest : IRequest<UpdateScheduleResponse>
    {
        public int ScheduleId { get; set; }
        public DateTime NewStartTime { get; set; }
        public double NewDurationInHours { get; set; }
    }
}
