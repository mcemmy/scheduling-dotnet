using MediatR;
using Microsoft.AspNetCore.Identity;
using StaffScheduler.Core.Application.Exceptions;
using StaffScheduler.Core.Application.Interfaces;

namespace StaffScheduler.Core.Application.UseCases.Staff.RemoveStaff
{
    public class RemoveStaffUseCase : IRequestHandler<RemoveStaffRequest, RemoveStaffResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IStaffRepository _staffRepository;

        public RemoveStaffUseCase(UserManager<IdentityUser> userManager,
            IStaffRepository staffRepository)
        {
            _userManager = userManager;
            _staffRepository = staffRepository;

        }

        public async Task<RemoveStaffResponse> Handle(RemoveStaffRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                throw new RecordNotFoundException(ExceptionMessages.StaffRecordNotFound);

            await _userManager.DeleteAsync(user);

            await _staffRepository.RemoveAsync(user.UserName);

            return new RemoveStaffResponse(Status.Accepted,Messages.Successful);

        }
    }
}
