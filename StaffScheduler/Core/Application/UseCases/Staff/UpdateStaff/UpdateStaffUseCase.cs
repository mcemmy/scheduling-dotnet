using MediatR;
using Microsoft.AspNetCore.Identity;
using StaffScheduler.Core.Application.Exceptions;
using StaffScheduler.Core.Application.Interfaces;

namespace StaffScheduler.Core.Application.UseCases.Staff.UpdateStaff
{
    public class UpdateStaffUseCase : IRequestHandler<UpdateStaffRequest, UpdateStaffResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IStaffRepository _staffRepository;
        
        public UpdateStaffUseCase(
            UserManager<IdentityUser> userManager,
            IStaffRepository staffRepository)
        {
            _userManager = userManager;
            _staffRepository = staffRepository;
        }
        public async Task<UpdateStaffResponse> Handle(UpdateStaffRequest request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                throw new RecordNotFoundException(ExceptionMessages.StaffRecordNotFound);

            user.PhoneNumber = request.PhoneNumber;
            user.Email = request.Email;
            
            var staff = new Domain.Staff(user, request.FirstName, request.LastName);
            
            await _userManager.UpdateAsync(user);
            await _staffRepository.UpdateAsync(staff);

            return new UpdateStaffResponse(Status.Accepted, Messages.Successful);
        }

       
    }
}
