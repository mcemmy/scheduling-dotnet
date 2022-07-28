using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using StaffScheduler.Core.Application.UseCases;

namespace StaffScheduler
{
    public class Result : ControllerBase
    {
        public Task<IActionResult> Get(BaseResponse response)
        {
            return Task.FromResult<IActionResult>(response.Status switch
            {
                Status.Ok => Ok(response),
                Status.Created => Created(string.Empty, response),
                Status.FatalError => StatusCode(StatusCodes.Status500InternalServerError, response),
                Status.NotFound => NotFound(response),
                Status.BadRequest => BadRequest(response),
                Status.Accepted => Accepted(response),
                _ => Ok()
            });
        }
    }
}
