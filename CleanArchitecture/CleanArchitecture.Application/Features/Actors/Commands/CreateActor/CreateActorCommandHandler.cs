using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Actors.Commands.CreateActor
{
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
       // private readonly IEmailService _emailservice;
        private readonly ILogger<CreateActorCommand> _logger;

        public CreateActorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, /*IEmailService emailservice,*/ ILogger<CreateActorCommand> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
           // _emailservice = emailservice;
            _logger = logger;
        }

        async Task<int> IRequestHandler<CreateActorCommand, int>.Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var actorEntity = _mapper.Map<Actor>(request);
            _unitOfWork.ActorRepository.AddEntity(actorEntity);
            var result = await _unitOfWork.Complete();


            if (result <= 0)
            {
                throw new Exception($"No se pudo insetar el record de Actor");
            }


            _logger.LogInformation($"Actor {actorEntity.Id} fue creado existosamente");


            return actorEntity.Id;
        }


    }
}
