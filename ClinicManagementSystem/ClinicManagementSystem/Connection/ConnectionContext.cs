using System.Data;
using System.Data.SqlClient;

namespace ClinicManagementSystem.Connection
{
    public class ConnectionContext
    {
       
            private readonly IConfiguration _configuration;
            private readonly string _connectionString;
            public ConnectionContext(IConfiguration configuration)
            {
                _configuration = configuration;
                _connectionString = _configuration.GetConnectionString("DbString");
            }
            public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
        

    }
}
