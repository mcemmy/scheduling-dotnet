namespace StaffScheduler.Core.Application.UseCases.Staff.CreateAccount
{
    public class CreateAccountResponse : BaseResponse
    {
        public CreateAccountResponse(Status status, string message) : base(status)
        {
            Message = message;
        }
    }
}
