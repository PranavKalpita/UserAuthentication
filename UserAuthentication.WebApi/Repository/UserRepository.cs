using Microsoft.Data.SqlClient;
using System.Data;
using UserAuthentication.WebApi.DatabaseConfig;
using UserAuthentication.WebApi.Models;

namespace UserAuthentication.WebApi.Repository
{
    public class UserRepository
    {

        private readonly DatabaseConfiguration dbConfig;
        public UserRepository(DatabaseConfiguration dbConfig)
        {
           this.dbConfig = dbConfig;
        }

        public async Task<User> GetUser()
        {
            await using (_dbConfig)
            {
                await _dbConfig.OpenAsync();

              
            }
        }

    }
}
