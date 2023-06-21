using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Features.Streamers.Commands;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Applictaion.UnitTests.Mocks;
using CleanArchitecture.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Applictaion.UnitTests.Features.Streamers.UpdateStreamer
{
    public class UpdateStreamerCommandHandlerXUnitTests
    {


        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<IEmailService> _emailService;
        private readonly Mock<ILogger<UpdateStreamerCommandHandler>> _logger;
        public UpdateStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = new Mock<UnitOfWork>();
            var mapperConfig = new MapperConfiguration(c =>
            {

                c.AddProfile<MappingProfile>();


            });
            _mapper = mapperConfig.CreateMapper();
            _emailService = new Mock<IEmailService>();
            _logger = new Mock<ILogger<UpdateStreamerCommandHandler>>();

            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);





        }
        [Fact]

        public async Task UpdateStreamerCommand_InputStreamer_RetrnsUnit()
        {
;

            var streamerInput = new UpdateStreamerCommand
            {
                Id = 8001,
                Nombre = "Vaxi Stream Max",
                Url = "Maximo.com"
            };

            var handler = new UpdateStreamerCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result= handler.Handle(streamerInput, CancellationToken.None);
            result.ShouldBeOfType<Unit>();

        }

    }
}
