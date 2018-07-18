using System.Collections.Generic;
using Infra.Entidades;

namespace Infra.Contratos.Interfaces
{
    public interface ICarroDapper : IDapperInfra<Carro>
    {
        //IEnumerable<Carro> GetAllCarros();

        IEnumerable<Carro> GetAllCarrosByProprietarioCodigo(int codigo);

        //Carro GetCarroByCodigo(int codigo);
    }
}