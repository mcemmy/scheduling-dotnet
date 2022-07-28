using MediatR;

namespace StaffScheduler.Core.Application.UseCases.Schedule.CreateSchedule
{
    public class CreateScheduleRequest : IRequest<CreateScheduleResponse>
    {
        public string Username { get; set; }
        public DateTime StartsFrom { get; set; }
        public double DurationInHours { get; set; }
    }
}
