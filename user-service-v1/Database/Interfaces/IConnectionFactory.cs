using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace user_service_v1.Database.Interfaces
{
    public interface IConnectionFactory
    {
        NpgsqlConnection CreateDBConnection();
    }
}
