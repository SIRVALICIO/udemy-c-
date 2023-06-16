using CleanArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IVideoRepository: IAsyncRepository<Video>
    {
        Task<Video> GetVideoByNombre(string nombreVideo);
        Task<IEnumerable< Video>> GetVideoByUsername(string username);
    }
}
