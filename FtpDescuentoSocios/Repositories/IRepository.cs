using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FtpDescuentoSocios.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);
        void Commit();
    }
}
