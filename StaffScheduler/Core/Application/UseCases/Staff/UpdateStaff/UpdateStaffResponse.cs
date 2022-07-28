namespace StaffScheduler.Core.Application.UseCases.Staff.UpdateStaff
{
    public class UpdateStaffResponse : BaseResponse
    {
        public UpdateStaffResponse(Status status, string message) : base(status)
        {
            Message = message;
        }
    }
}
