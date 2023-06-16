using AutoMapper;
using CleanArchitecture.Application.Features.Streamers.Commands;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideoList;
using CleanArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile: Profile    {
        public MappingProfile()
        {

            CreateMap<Video, VideosVm>();

            CreateMap<StreamerCommand, Streamer>();
        }
    }

}
