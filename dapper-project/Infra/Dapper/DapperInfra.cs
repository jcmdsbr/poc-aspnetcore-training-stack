using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Infra.Contratos.Interfaces;
using Infra.Entidades;
using Infra.Interfaces.Interfaces;

namespace Infra.Dapper
{

    public abstract class DapperInfra<T> : IDapperInfra<T> where T : EntidadeBase, new()
    {
        protected readonly IConnectionFactory _connectionFactory;
        protected DapperInfra(IConnectionFactory connectionFactory) 
        => _connectionFactory = connectionFactory;

        public virtual T SaveOrUpdate(T entity)
        {
            if (entity.Codigo > 0)
                Update(entity);
            else 
                Save(entity);

            return entity;
        }

        public virtual T Get(int codigo)
        {
            T entity;

            using (var connection = _connectionFactory.GetConnection())
            {
                entity =  connection.Get<T>(codigo);
            }

            return entity;
        }

        public virtual IEnumerable<T> GetAll()
        {
            IEnumerable<T> entities;

            using (var connection = _connectionFactory.GetConnection())
            {
                entities = connection.GetAll<T>();
            }

            return entities;
        }

        public virtual void Delete(T entity)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                connection.Delete(entity);
            }
        }

        public virtual void DeleteAll()
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                connection.DeleteAll<T>();
            }
        }
        
        private void Update(T entity)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                connection.Update(entity);
            }   
        }

        private void Save(T entity)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                connection.Insert(entity);
            }
        }
    }
}