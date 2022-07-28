using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using StaffScheduler.Core.Application.UseCases.Schedule.ViewSchedule;
using StaffScheduler.Core.Application.UseCases.Staff.ViewStaff;

namespace StaffScheduler.Controllers
{
    [Authorize]
    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
      
         private readonly IMediator _mediator;
         private readonly Result _result;

        public StaffController(IMediator mediator)
        {
            _mediator = mediator;
            _result = new Result();
        }

        /// <summary>
        /// Return authenticated staff basic profile.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        [Route("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var username = User?.Identity?.Name;
            if (username == null)
                return Unauthorized();

            var request = new ViewStaffRequest(username);

            var response = await _mediator.Send(request);

            return await _result.Get(response);

        }

        /// <summary>
        /// Return authenticated staff schedule for a period of time.
        /// </summary>
        /// <param name="periodInMonths"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("my-schedules")]
        public async Task<IActionResult> MySchedules([FromQuery] int periodInMonths)
        {
            
                var username = User?.Identity?.Name;
                if (username == null)
                    return Unauthorized();

                var request = new ViewScheduleRequest()
                {
                    UserName = username,
                    WithinPeriodInMonths = periodInMonths
                };
          
           
            var response = await _mediator.Send(request);

            return await _result.Get(response);
        }
        
        /// <summary>
        /// Return staff schedules by their username.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("schedules")]
        public async Task<IActionResult> Schedules([FromQuery] ViewScheduleRequest request)
        {
            var response = await _mediator.Send(request);

            return await _result.Get(response);
        }


    }
}
