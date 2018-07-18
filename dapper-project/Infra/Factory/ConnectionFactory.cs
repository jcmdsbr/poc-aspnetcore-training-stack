using System.Data.SqlClient;
using Infra.Interfaces.Interfaces;

namespace Infra.Factory
{
    public  class ConnectionFactory : IConnectionFactory
    {

        private readonly string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString); 
        }
    }
}