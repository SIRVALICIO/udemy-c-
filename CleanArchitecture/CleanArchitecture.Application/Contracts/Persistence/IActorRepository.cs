using CleanArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IActorRepository : IAsyncRepository<Actor>
    {
           
    }
}
