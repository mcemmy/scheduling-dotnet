using MediatR;

namespace StaffScheduler.Core.Application.UseCases.Schedule.ViewSchedule
{
    public class ViewScheduleRequest : IRequest<ViewScheduleResponse>
    {
        public string UserName { get; set; }
        public int WithinPeriodInMonths { get; set; }
    }
}
