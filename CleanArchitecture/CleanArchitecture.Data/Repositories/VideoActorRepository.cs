using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class VideoActorRepository : RepositoryBase<VideoActor>, IVideoActorRepository
    {
        public VideoActorRepository(StreamerDbContext context) : base(context)
        {
        }
    }
}
