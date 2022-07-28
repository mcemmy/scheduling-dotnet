using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaffScheduler.Core.Application.Common;
using StaffScheduler.Core.Application.UseCases.Staff.RemoveStaff;
using StaffScheduler.Core.Application.UseCases.Staff.UpdateStaff;
using StaffScheduler.Core.Application.UseCases.Staff.ViewAllStaff;

namespace StaffScheduler.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly Result _result;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
            _result = new Result();
        }

        /// <summary>
        /// Update a staff record.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("staff")]
        public async Task<IActionResult> UpdateRecord(UpdateStaffRequest request)
        {
            var response = await _mediator.Send(request);

            return await _result.Get(response);
        }
        
        /// <summary>
        /// Remove a staff from the system the the username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>

        [HttpDelete]
        [Route("staff/{username}")]
        public async Task<IActionResult> Remove(string username)
        {
            var request = new RemoveStaffRequest(username);

            var response = await _mediator.Send(request);

            return await _result.Get(response);

        }

        /// <summary>
        /// Return all staff in order of their accumulated work hours.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("staffs")]
        public async Task<IActionResult> GetAll([FromQuery]ViewAllStaffRequest request)
        {
          
            var response = await _mediator.Send(request);

            return await _result.Get(response);

        }

     
    }
}
