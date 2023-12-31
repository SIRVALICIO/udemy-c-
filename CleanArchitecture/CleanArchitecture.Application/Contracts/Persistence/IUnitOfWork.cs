﻿using CleanArchitecture.Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface  IUnitOfWork:IDisposable



    {



        IActorRepository ActorRepository { get; }
        IStreamerRepository StreamerRepository { get; }
        IVideoRepository VideoRepository { get; }

        IVideoActorRepository VideoActorRepository { get; }
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity: BaseDomainModel;

        Task<int> Complete();

    }
}
