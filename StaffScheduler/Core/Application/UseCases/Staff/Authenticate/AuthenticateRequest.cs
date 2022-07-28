using MediatR;

namespace StaffScheduler.Core.Application.UseCases.Staff.Authenticate
{
    public class AuthenticateRequest : IRequest<AuthenticateResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
