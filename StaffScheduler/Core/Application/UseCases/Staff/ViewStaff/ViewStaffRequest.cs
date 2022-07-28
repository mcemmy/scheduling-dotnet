using MediatR;

namespace StaffScheduler.Core.Application.UseCases.Staff.ViewStaff
{
    public class ViewStaffRequest : IRequest<ViewStaffResponse>
    {
        public string UserName { get; set; }
     
        public ViewStaffRequest(string userName)
        {
            UserName = userName;
        }
    }
}
