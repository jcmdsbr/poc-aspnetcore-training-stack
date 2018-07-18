using System.Collections.Generic;
using Dapper;
using Flepper.QueryBuilder;
using Infra.Contratos.Interfaces;
using Infra.Entidades;
using Infra.Interfaces.Interfaces;
using static Flepper.QueryBuilder.FlepperQueryBuilder;

namespace Infra.Dapper
{
    public class CarroDapper : DapperInfra<Carro>, ICarroDapper
    {

       public CarroDapper(IConnectionFactory connectionFactory) : base(connectionFactory)
       {
       }

        public IEnumerable<Carro> GetAllCarrosByProprietarioCodigo(int codigo)
        {
            IEnumerable<Carro> carros;

            var query = "SELECT  c.Codigo, c.Modelo, c.Fabricante,c.AnoFabricacao, p.Codigo, p.Nome, p.Idade " +
                        " FROM[dbo].[Carro] as c " +
                        " INNER JOIN[dbo].Pessoa as p on p.Codigo = c.ProprietarioCodigo" +
                        $"WHERE p.Codigo = {codigo}";

            using (var connection = _connectionFactory.GetConnection())
            {
                carros = connection.Query<Carro, Pessoa, Carro>(query, (carro, pessoa) =>
                {
                    carro.Proprietario = pessoa;
                    return carro;
                }, splitOn: "Codigo");
            }

            return carros;
        }

        public override IEnumerable<Carro> GetAll()
        {
            IEnumerable<Carro> carros;

            var query = Select()
                .From(nameof(Carro)).As("c")
                .LeftJoin(nameof(Pessoa)).As("p")
                .On("c", "ProprietarioCodigo")
                .EqualTo("p", "Codigo").Build();

            using (var connection = _connectionFactory.GetConnection())
            {
                carros = connection.Query<Carro, Pessoa, Carro>(query, (c, p) =>
                {
                    c.Proprietario = p;
                    return c;

                },splitOn:"Codigo");
            }

            return carros;
        }
    }
}