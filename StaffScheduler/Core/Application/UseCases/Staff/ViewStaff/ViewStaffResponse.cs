using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace StaffScheduler.Core.Application.UseCases.Staff.ViewStaff
{
    public class ViewStaffResponse : BaseResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FirstName { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string LastName { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PhoneNumber { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime JoinedOn { get; set; }

        public ViewStaffResponse(Status status, string firstName, string lastName, string phoneNumber) : base(status)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        public ViewStaffResponse(Status status, string message) : base(status)
        {
            Message = message;
        }
    }
}
