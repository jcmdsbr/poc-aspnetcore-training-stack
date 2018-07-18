using System;
using System.Collections.Generic;
using System.Linq;
using Application.Repository;
using Domain.Entities.Core;
using Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly CustomerContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(CustomerContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public TEntity FindById(Guid id)
        {
            return DbSet.Find(id);
        }

        public List<TEntity> List()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void Delete(Guid id)
        {
            DbSet.Remove(FindById(id));
        }
    }
}