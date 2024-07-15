using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace Journal.Data
{
    public class MySqlData
    {
        private readonly IConfiguration _configuration;
        public MySqlData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IDbConnection> OpenConnectionAsync()
        {
            var connection = new MySqlConnection(_configuration.GetSection("ConnectionString").Value);
            await connection.OpenAsync();
            return connection;
        }
    }
}
