using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {

        private readonly IStreamerRepository _streamRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailservice;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IStreamerRepository streamRepository, IMapper mapper, IEmailService emailservice, ILogger<CreateStreamerCommandHandler> logger)
        {
            _streamRepository = streamRepository;
            _mapper = mapper;
            _emailservice = emailservice;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);
            var newStreamer = await _streamRepository.AddAsync(streamerEntity);

            _logger.LogInformation($"Streamer {newStreamer.Id} fue creado exisotamente");

            await SendEmail(newStreamer);


            return newStreamer.Id;
        }

        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email
            {

                To = "paula.caicedo.2019@upb.edu.com",
                Body = "La compañia d estreanmer se creo correctamente",
                Subject = "Mensaje de alerta"
            };

            try
            {



                await _emailservice.SendEmail(email);

            }
            catch (Exception ex)
            {

                _logger.LogError($"Erores enviados al Email de {streamer.Id}");
            }
        }
    }
}
