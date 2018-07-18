using System.Collections.Generic;

namespace Infra.Contratos.Interfaces
{
    public interface IDapperInfra<T>
    {
        T SaveOrUpdate(T entity);
        
        
        T Get(int codigo);

        IEnumerable<T> GetAll();

        void Delete(T entity);

        void DeleteAll();
    }
}