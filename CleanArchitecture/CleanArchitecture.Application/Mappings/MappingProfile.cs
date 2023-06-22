using AutoMapper;
using CleanArchitecture.Application.Features.Actors.Commands.CreateActor;
using CleanArchitecture.Application.Features.Directors.Commands.CreateDirector;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Features.VideoActors.CreateVideoActors;
using CleanArchitecture.Application.Features.Videos.Commands.CreateVideo;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVm>();
            CreateMap<CreateVideoCommand, Streamer>();
            CreateMap<CreateDirectorCommand, Director>();
            CreateMap<UpdateStreamerCommand, Streamer>();
            CreateMap<CreateVideoCommand, Video>();
            CreateMap<CreateActorCommand, Actor>();
            CreateMap<CreateVideoActorCommand, VideoActor>();

        }
    }
}
