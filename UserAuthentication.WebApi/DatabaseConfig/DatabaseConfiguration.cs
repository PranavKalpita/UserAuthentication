using Microsoft.Data.SqlClient;

namespace UserAuthentication.WebApi.DatabaseConfig
{
    public class DatabaseConfiguration : IAsyncDisposable
    {
        private readonly SqlConnection _connection;

        public DatabaseConfiguration(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public async Task OpenAsync()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                await _connection.OpenAsync();
            }
        }

        public SqlConnection GetConnection() => _connection;

        public async ValueTask DisposeAsync()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                await _connection.CloseAsync();
            }
            await _connection.DisposeAsync();
        }
    }
}
