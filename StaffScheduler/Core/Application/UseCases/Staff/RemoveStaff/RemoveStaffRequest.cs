using MediatR;

namespace StaffScheduler.Core.Application.UseCases.Staff.RemoveStaff
{
    public class RemoveStaffRequest : IRequest<RemoveStaffResponse>
    {
        public string UserName { get; set; }

        public RemoveStaffRequest(string userName)
        {
            UserName = userName;
        }
    }
}
