﻿using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Persistence;
using System.Collections;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private Hashtable _repositories;
        private readonly StreamerDbContext _context;

        private  IVideoRepository _videoRepository;
        private IVideoActorRepository _videoActorRepository;
        private  IStreamerRepository _streamerRepository;
        private IActorRepository _actorRepository;


        public IVideoActorRepository VideoActorRepository=> _videoActorRepository ??= new VideoActorRepository(_context);
        public IActorRepository ActorRepository=> _actorRepository ??= new ActorRepository(_context);
        public IVideoRepository VideoRepository => _videoRepository ??= new VideoRepository(_context);
        public IStreamerRepository StreamerRepository=> _streamerRepository??= new StreamerRepository(_context);

        public UnitOfWork(StreamerDbContext context)
        {
            _context = context;
        }

        public StreamerDbContext StreamerDbContext => _context;



        public async Task<int> Complete()
        {
            try { return await _context.SaveChangesAsync(); } catch (Exception) { throw new Exception("Err"); }



        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {

                var repositoyType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoyType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);

            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
