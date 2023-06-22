using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.VideoActors.CreateVideoActors
{
    public class CreateVideoActorCommand : IRequest<int>
    {



        public int VideoId { get; set; }
        public int ActorId { get; set; }
    }
}
