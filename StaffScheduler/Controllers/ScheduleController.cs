using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaffScheduler.Core.Application.Common;
using StaffScheduler.Core.Application.UseCases.Schedule.CreateSchedule;
using StaffScheduler.Core.Application.UseCases.Schedule.RemoveSchedule;
using StaffScheduler.Core.Application.UseCases.Schedule.UpdateSchedule;
using StaffScheduler.Core.Application.UseCases.Schedule.ViewSchedule;

namespace StaffScheduler.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/admin/schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly  IMediator _mediator;
        private readonly Result _result;

        public ScheduleController(IMediator mediator)
        {
            _mediator = mediator;
            _result = new Result();

        }

        /// <summary>
        /// Create a work schedule for a staff.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CreateScheduleRequest request)
        {
            var response = await _mediator.Send(request);

            return await _result.Get(response);

        }

        /// <summary>
        /// Update already created work schedule for a staff.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(UpdateScheduleRequest request)
        {
            var response = await _mediator.Send(request);

            return await _result.Get(response);
        }

        /// <summary>
        /// Delete a work schedule for a staff.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(RemoveScheduleRequest request)
        {
            var response = await _mediator.Send(request);

            return await _result.Get(response);
        }
        
    }
}
