﻿using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        //private readonly IStreamerRepository _streamerRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailservice;
        private readonly ILogger<CreateStreamerCommand> _logger;

        public CreateStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailservice, ILogger<CreateStreamerCommand> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailservice = emailservice;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);
            //var newStreamer = await _streamerRepository.AddAsync(streamerEntity);
             _unitOfWork.StreamerRepository.AddEntity(streamerEntity);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insetar el record de stramer");
            }


            _logger.LogInformation($"Streamer {streamerEntity.Id} fue creado existosamente");

            await SendEmail(streamerEntity);

            return streamerEntity.Id;
        }

        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email
            {
                To = "vaxi.drez.social@gmail.com",
                Body = "La compania de streamer se creo correctamente",
                Subject = "Mensaje de alerta"
            };

            try
            {
                await _emailservice.SendEmail(email);
            }
            catch (Exception ex) {
                _logger.LogError($"Errores enviando el email de {streamer.Id}");
            }

        }

    }
}
