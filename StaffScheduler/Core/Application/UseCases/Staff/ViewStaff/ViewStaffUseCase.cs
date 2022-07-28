using MediatR;
using Microsoft.AspNetCore.Identity;
using StaffScheduler.Core.Application.Exceptions;
using StaffScheduler.Core.Application.Interfaces;

namespace StaffScheduler.Core.Application.UseCases.Staff.ViewStaff
{
    public class ViewStaffUseCase :IRequestHandler<ViewStaffRequest, ViewStaffResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IStaffRepository _staffRepository;
        private readonly ILogger _logger;
        public ViewStaffUseCase(UserManager<IdentityUser> userManager, IStaffRepository staffRepository, ILogger<ViewStaffUseCase> logger)
        {
            _userManager = userManager;
            _staffRepository = staffRepository;
            _logger = logger;
        }
        public async Task<ViewStaffResponse> Handle(ViewStaffRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);
                if (user == null)
                    throw new RecordNotFoundException(ExceptionMessages.StaffRecordNotFound);

                var staffRecord = await _staffRepository.GetAsync(request.UserName);
                
                return new ViewStaffResponse(
                    Status.Ok,
                    staffRecord.FirstName,
                    staffRecord.LastName,
                    user.PhoneNumber)
                {
                    JoinedOn = staffRecord.JoinedOn
                };
            }
            catch (RecordNotFoundException exception)
            {
                _logger.LogError(exception, exception.Message);
                return new ViewStaffResponse(Status.NotFound,ExceptionMessages.StaffRecordNotFound);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new ViewStaffResponse(Status.FatalError,ExceptionMessages.UnexpectedError);
            }
            
        }
    }
}
