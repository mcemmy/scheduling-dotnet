using MediatR;

namespace StaffScheduler.Core.Application.UseCases.Staff.UpdateStaff
{
    public class UpdateStaffRequest : IRequest<UpdateStaffResponse>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
