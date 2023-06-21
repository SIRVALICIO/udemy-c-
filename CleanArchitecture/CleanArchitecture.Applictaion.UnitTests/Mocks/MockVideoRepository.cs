using AutoFixture;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Applictaion.UnitTests.Mocks
{
    public static class MockVideoRepository
    {

        public static void AddDataVideoRepository(StreamerDbContext streamerDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var videos = fixture.CreateMany<Video>().ToList();

            videos.Add(fixture.Build<Video>().With(tr => tr.CreatedBy, "Val").Create() );

            /*
            var options = new DbContextOptionsBuilder<StreamerDbContext>().UseInMemoryDatabase(databaseName: $"StreamerDbContext-{Guid.NewGuid}").
                Options;

            var streamerDbContextFake = new StreamerDbContext(options);
            */
            streamerDbContextFake.Videos!.AddRange(videos);
            streamerDbContextFake.SaveChanges();

            //var mockRepository = new Mock<VideoRepository>(streamerDbContextFake);

            //mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(videos);
            //return mockRepository;

        }
    }
}
