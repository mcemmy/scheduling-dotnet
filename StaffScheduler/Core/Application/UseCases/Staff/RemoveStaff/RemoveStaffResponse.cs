namespace StaffScheduler.Core.Application.UseCases.Staff.RemoveStaff
{
    public class RemoveStaffResponse : BaseResponse
    {
        public RemoveStaffResponse(Status status, string message) : base(status)
        {
            Message = message;
        }
    }
}
