using System.Text.Json.Serialization;
using MediatR;

namespace StaffScheduler.Core.Application.UseCases.Staff.CreateAccount
{
    public class CreateAccountRequest : IRequest<CreateAccountResponse>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
       
        [JsonIgnore]
        public bool IsAdmin { get; set; }

        public void BecomeAdmin()
        {
            IsAdmin = true;
        }
    }
}
