using System.Data.SqlClient;

namespace Infra.Interfaces.Interfaces
{
    public interface IConnectionFactory
    {
        SqlConnection GetConnection();
    }
}