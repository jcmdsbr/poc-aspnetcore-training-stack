using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Infra.Contratos.Interfaces;
using Infra.Entidades;
using Infra.Interfaces.Interfaces;

namespace Infra.Dapper
{
    public class PessoaDapper : DapperInfra<Pessoa>, IPessoaDapper
    {
        public PessoaDapper(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}