using System;
using System.Collections.Generic;
using Domain.Entities.Core;

namespace Application.Repository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity FindById(Guid id);
        List<TEntity> List();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
    }
}