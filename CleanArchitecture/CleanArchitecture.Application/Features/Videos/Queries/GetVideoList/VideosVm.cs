using CleanArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideoList
{
    internal class VideosVm
    {

        public string? Nombre { get; set; }

        public int StreamerId { get; set; }
    }
}
