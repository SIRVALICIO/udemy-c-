using AutoMapper;
using Castle.Core.Logging;
using CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer;
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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Applictaion.UnitTests.Features.Streamers.DeleteStreamer
{
    public class DeleteStreamerCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<DeleteStreamerCommandHandler>> _logger;



        public DeleteStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c=>{
                c.AddProfile<MappingProfile>();
               



            });
            _mapper=mapperConfig.CreateMapper();
            _logger=new Mock<ILogger<DeleteStreamerCommandHandler>>();
            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);



            




        }



        [Fact] public async Task UpdateStreamerCommand_InputStreamerById_ReturnsUnit()
        {

            var streamerInput = new DeleteStreamerCommand
            {

                Id = 1000
            };


            var handler = new DeleteStreamerCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(streamerInput, CancellationToken.None);
            result.ShouldBeOfType<Unit>();
        }



    }
}
