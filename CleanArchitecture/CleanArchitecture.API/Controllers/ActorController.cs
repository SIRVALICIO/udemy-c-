using CleanArchitecture.Application.Features.Actors.Commands.CreateActor;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ActorController
    {


        private IMediator _mediator;

        public ActorController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost("Actor")]
        //[Authorize(Roles = "Administrador")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateStreamer([FromBody] CreateActorCommand command)
        {
            return await _mediator.Send(command);
        }

    }


}
