using CleanArchitecture.Application.Contracts.Persistence;
using Moq;
using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Applictaion.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {

        public static Mock<UnitOfWork> GetUnitOfWork()
        {

            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<StreamerDbContext>()
                .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{dbContextId}")
                .Options;

            var streamerDbContextFake = new StreamerDbContext(options);


            streamerDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(streamerDbContextFake);
            //var mockVideoRepository = MockVideoRepository.GetVideoRepository(
            //mockUnitOfWork.Setup(r => r.VideoRepository).Returns(mockVideoRepository.Object);



            return mockUnitOfWork;

        }

    }
}
