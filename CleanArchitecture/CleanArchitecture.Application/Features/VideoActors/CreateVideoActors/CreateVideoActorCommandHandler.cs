using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Directors.Commands.CreateDirector;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Features.VideoActors.CreateVideoActors

{

    public class CreateVideoActorCommandHandler : IRequestHandler<CreateVideoActorCommand, int>


    {

        private readonly ILogger<CreateVideoActorCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateVideoActorCommandHandler(ILogger<CreateVideoActorCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateVideoActorCommand request, CancellationToken cancellationToken)
        {
            var VideoActorEntity = _mapper.Map<VideoActor>(request);

            var actrorExist= await _unitOfWork.ActorRepository.GetByIdAsync(VideoActorEntity.ActorId);

            var videoExist = await _unitOfWork.VideoRepository.GetByIdAsync(VideoActorEntity.VideoId);


            if(videoExist==null || actrorExist == null)
            {

                return -1;
            }



            _logger.LogInformation($"Streamer {VideoActorEntity.Id} fue creado existosamente");



            return VideoActorEntity.Id;
        }
    }
}
