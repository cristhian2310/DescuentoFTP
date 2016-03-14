using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using FtpDescuentoSocios.Model;
using FtpDescuentoSocios.Repositories;

namespace FtpDescuentoSocios.Services
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        protected readonly DbContext Context;

        protected Service()
        {
            Context = new eFarmaxEntities();
            _repository = new Repository<TEntity>(Context);
        } 

        public void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.GetBy(predicate);
        }

        public void Commit()
        {
            _repository.Commit();
        }
    }
}
