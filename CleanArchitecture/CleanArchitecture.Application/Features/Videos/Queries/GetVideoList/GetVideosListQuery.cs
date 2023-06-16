using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideoList
{
    public class GetVideosListQuery: IRequest<List<VideosVm>>
    {
        public string _Username { get; set; } = String.Empty;
        public GetVideosListQuery (string username)
        {
            _Username = username ?? throw new ArgumentNullException(nameof(username));
        }

    }
}
