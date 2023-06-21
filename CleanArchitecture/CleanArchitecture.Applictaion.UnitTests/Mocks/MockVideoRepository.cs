using AutoFixture;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using Moq;

namespace CleanArchitecture.Applictaion.UnitTests.Mocks
{
    public static class MockVideoRepository
    {

        public static Mock<IVideoRepository> GetVideoRepository()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var videos = fixture.CreateMany<Video>().ToList();

            videos.Add(fixture.Build<Video>().With(tr => tr.CreatedBy, "Val").Create() );

            var mockRepository = new Mock<IVideoRepository>();

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(videos);
            return mockRepository;

        }
    }
}
