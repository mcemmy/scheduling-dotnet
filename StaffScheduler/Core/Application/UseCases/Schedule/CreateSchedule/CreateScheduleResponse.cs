namespace StaffScheduler.Core.Application.UseCases.Schedule.CreateSchedule
{
    public class CreateScheduleResponse : BaseResponse
    {
        public CreateScheduleResponse(Status status, string message) : base(status)
        {
            Message = message;
        }
    }
}
