using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandhandler : IRequestHandler<DeleteStreamerCommand>
    {

        private readonly IStreamerRepository _streamerRepository;
        private readonly ILogger<DeleteStreamerCommandhandler> _logger;

        private readonly IMapper _mapper;

        public DeleteStreamerCommandhandler(IStreamerRepository streamerRepository, ILogger<DeleteStreamerCommandhandler> logger, IMapper mapper)
        {
            _streamerRepository = streamerRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToDelete = await _streamerRepository.GetByIdAsync(request.Id);

            if (streamerToDelete == null)
            {

                _logger.LogError($"{request.Id} streamer no existe en la base de datos");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            await _streamerRepository.DeleteAsync(streamerToDelete);

            _logger.LogInformation($"{request.Id} streamer fue eliminado con exito");

            return Unit.Value;
        }
    }
}
