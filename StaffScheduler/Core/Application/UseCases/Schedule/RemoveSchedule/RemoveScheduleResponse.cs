using System.Runtime.CompilerServices;

namespace StaffScheduler.Core.Application.UseCases.Schedule.RemoveSchedule
{
    public class RemoveScheduleResponse : BaseResponse
    {
        public RemoveScheduleResponse( Status status, string message) : base(status)
        {
            Message = message;
        }
    }
}
