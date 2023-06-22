using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Videos.Commands.CreateVideo
{
    public class CreateVideoCommandHandler : IRequestHandler<CreateVideoCommand, int>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailservice;
        private readonly ILogger<CreateVideoCommandHandler> _logger;

        public CreateVideoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailservice, ILogger<CreateVideoCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailservice = emailservice;
            _logger = logger;
        }

        public async Task<int> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
        {
            var videoEntity = _mapper.Map<Video>(request);
            //var newStreamer = await _streamerRepository.AddAsync(streamerEntity);

            var existensia = await _unitOfWork.StreamerRepository.GetByIdAsync(request.StreamerId);
            if (existensia == null) {

                //throw new Exception($"No se pudo insetar el record de video dado que no existe el streamer");
                return 0;
            
            }

            _unitOfWork.VideoRepository.AddEntity(videoEntity);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insetar el record de video");
            }


            _logger.LogInformation($"Streamer {videoEntity.Id} fue creado existosamente");

            //await SendEmail(videoEntity);

            return videoEntity.Id;
        }


    }
}

