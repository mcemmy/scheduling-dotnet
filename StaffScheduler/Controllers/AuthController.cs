using Microsoft.AspNetCore.Mvc;
using MediatR;
using StaffScheduler.Core.Application.UseCases.Staff.Authenticate;
using StaffScheduler.Core.Application.UseCases.Staff.CreateAccount;

namespace StaffScheduler.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly Result _result;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
            _result = new Result();

        }

        /// <summary>
        /// Generate authentication token to access authorized endpoints.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(AuthenticateRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        /// <summary>
        /// Register as a staff on the system. Password should be alphanumeric with at least 1 capital letter and a symbol
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(CreateAccountRequest request)
        {
            var response = await _mediator.Send(request);

            return await _result.Get(response);
        }


        /// <summary>
        /// Register as an administrative staff on the system. Password should be alphanumeric with at least 1 capital letter and a symbol
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin(CreateAccountRequest request)
        {
            request.BecomeAdmin();

            var response = await _mediator.Send(request);

            return await _result.Get(response);
        }


    }


}
