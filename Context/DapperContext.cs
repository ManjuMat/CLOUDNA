using System.Data.SqlClient;
using System.Data;

namespace CLOUDNA.Context
{
    public class DapperContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public DapperContext(IConfiguration configuration)
        {
            configuration = configuration;
            connectionString = configuration.GetConnectionString("MyDBConnection");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(connectionString);
    }
}
