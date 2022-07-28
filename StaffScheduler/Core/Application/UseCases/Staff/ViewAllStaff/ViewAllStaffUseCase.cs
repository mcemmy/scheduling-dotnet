using MediatR;
using Microsoft.AspNetCore.Identity;
using StaffScheduler.Core.Application.Interfaces;

namespace StaffScheduler.Core.Application.UseCases.Staff.ViewAllStaff
{
    public class ViewAllStaffUseCase : IRequestHandler<ViewAllStaffRequest, ViewAllStaffResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IStaffRepository _staffRepository;


        public ViewAllStaffUseCase(UserManager<IdentityUser> userManager, IStaffRepository staffRepository)
        {
            _userManager = userManager;
            _staffRepository = staffRepository;
        }
        public async Task<ViewAllStaffResponse> Handle(ViewAllStaffRequest request, CancellationToken cancellationToken)
        {
            var userNames = _userManager.Users.Select(x => x.UserName).ToList();

            var records = await _staffRepository.GetAllAsync(userNames, request.PeriodInMonths);

            var result = new ViewAllStaffResponse(Status.Ok);

            foreach (var record in records)
            {
                result.Records.Add(new StaffRecord(record.FirstName, record.LastName, record.AccumulatedHours()));
            }

            result.OrderByAccumulatedHours();

            return result;
        }
    }
}
