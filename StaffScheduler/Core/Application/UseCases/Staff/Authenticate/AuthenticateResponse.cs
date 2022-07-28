namespace StaffScheduler.Core.Application.UseCases.Staff.Authenticate
{
    public class AuthenticateResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
