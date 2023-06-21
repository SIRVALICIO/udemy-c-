using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Applictaion.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Applictaion.UnitTests.Features.Video.Queries
{
    public class GetVideosListQueryHandlerXUnitTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public GetVideosListQueryHandlerXUnitTest()
        {

            _unitOfWork=MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        
        }

        [Fact]

        public async Task GetVideoListTest()
        {
            var handler = new GetVideosListQueryHandler(_unitOfWork.Object,_mapper);
            var request = new GetVideosListQuery("system");
            var result= await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<VideosVm>>();
        }

    }
}
