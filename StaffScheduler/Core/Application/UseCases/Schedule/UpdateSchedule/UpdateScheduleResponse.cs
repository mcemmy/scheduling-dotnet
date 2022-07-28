namespace StaffScheduler.Core.Application.UseCases.Schedule.UpdateSchedule
{
    public class UpdateScheduleResponse : BaseResponse
    {
        public UpdateScheduleResponse(Status status, string message): base(status, message)
        {
            Message = message;
        }
    }
}
