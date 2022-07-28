using MediatR;
using Microsoft.AspNetCore.Identity;
using StaffScheduler.Core.Application.Common;
using StaffScheduler.Core.Application.Exceptions;
using StaffScheduler.Core.Application.Interfaces;

namespace StaffScheduler.Core.Application.UseCases.Staff.CreateAccount
{
    public class CreateAccountUseCase : IRequestHandler<CreateAccountRequest, CreateAccountResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IStaffRepository _staffRepository;

        public CreateAccountUseCase(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IStaffRepository staffRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _staffRepository = staffRepository;
        }

        public async Task<CreateAccountResponse> Handle(CreateAccountRequest request,
            CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByNameAsync(request.UserName);

            if (userExists != null)
                throw new UserExistException(ExceptionMessages.UserAlreadyExist);

            IdentityUser user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.UserName
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded) return new CreateAccountResponse(Status.Ok,Messages.UserCreationFailed);

            await AddUserToRoleAsync(user, request.IsAdmin);

            await _staffRepository.CreateAsync(new Domain.Staff
            {
                FirstName = request.Firstname,
                LastName = request.Lastname,
                JoinedOn = DateTime.UtcNow,
                User = user,
            });

            return new CreateAccountResponse(Status.Created, Messages.UserCreationSucceeded);

            //TODO: Exception should remove user if already created

        }

        private async Task AddUserToRoleAsync(IdentityUser user, bool isAdmin)
        {
            if (isAdmin)
            {
                if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            await _userManager.AddToRoleAsync(user, UserRoles.User);

        }
    }
}
