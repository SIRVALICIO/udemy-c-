using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class StreamerCommand : IRequest<int>
    {

        public string Nombre { get; set; } = string.Empty;

        public string Url { get; set; } = String.Empty;

    } 
}
