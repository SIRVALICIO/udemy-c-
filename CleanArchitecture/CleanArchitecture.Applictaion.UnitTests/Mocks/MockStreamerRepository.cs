using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Applictaion.UnitTests.Mocks
{
    public static class MockStreamerRepository
    {


        public static void AddDataStreamerRepository(StreamerDbContext streamerDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var _streamaers = fixture.CreateMany<Streamer>().ToList();

            _streamaers.Add(fixture.Build<Streamer>().With(tr => tr.Id, 8001).Without(tr=>tr.Videos).Create());

            /*
            var options = new DbContextOptionsBuilder<StreamerDbContext>().UseInMemoryDatabase(databaseName: $"StreamerDbContext-{Guid.NewGuid}").
                Options;

            var streamerDbContextFake = new StreamerDbContext(options);
            */
            streamerDbContextFake.Streamers!.AddRange(_streamaers);
            streamerDbContextFake.SaveChanges();

            //var mockRepository = new Mock<VideoRepository>(streamerDbContextFake);

            //mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(videos);
            //return mockRepository;

        }
    }


}

