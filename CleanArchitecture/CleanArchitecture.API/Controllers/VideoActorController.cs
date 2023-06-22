using CleanArchitecture.Application.Features.Streamers.Commands;
using CleanArchitecture.Application.Features.VideoActors.CreateVideoActors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace CleanArchitecture.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class VideoActorController
    {
        private IMediator _mediator;

        public VideoActorController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpPost("CreateVideoActor")]
        //[Authorize(Roles = "Administrador")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateVideoActor ([FromBody] CreateVideoActorCommand command)
        {
            return await _mediator.Send(command);
        }


    }
}
