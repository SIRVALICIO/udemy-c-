
using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Features.Streamers.Commands;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Applictaion.UnitTests.Mocks;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Applictaion.UnitTests.Features.Streamers.CreateStreamer
{
    public class CreateStreamerCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<IEmailService> _emailService;
        private readonly Mock<ILogger<CreateStreamerCommand>> _logger;
        public CreateStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = new Mock<UnitOfWork>();
            var mapperConfig = new MapperConfiguration(c =>
            {

                c.AddProfile<MappingProfile>();


            });
            _mapper = mapperConfig.CreateMapper();
            _emailService = new Mock<IEmailService>();
            _logger = new Mock<ILogger<CreateStreamerCommand>>();

            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);





        }
        [Fact]

        public async Task CreateStreamerCommand_InputStreamer_RetrnsNumbre()
        {

            var streamerInput = new CreateStreamerCommand
            {
                Nombre = "Netflix del chino",
                Url = "http://NetflixDelChino.com.co"
            };

            var handler = new CreateStreamerCommandHandler(_unitOfWork.Object, _mapper, _emailService.Object, _logger.Object);
            var result = handler.Handle(streamerInput, CancellationToken.None);
            result.ShouldBeOfType<int>();

        }



    }
}
