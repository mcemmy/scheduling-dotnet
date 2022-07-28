using MediatR;

namespace StaffScheduler.Core.Application.UseCases.Staff.ViewAllStaff
{
    public class ViewAllStaffRequest :IRequest<ViewAllStaffResponse>
    {
        public int PeriodInMonths { get; set; }
    }
}
