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

        public async Task<User> GetUser(string email, string password)
        {

            await using (dbConfig)
            {
                await dbConfig.OpenAsync();

                User user = null;
                using (var command = new SqlCommand("LoginUserGetDetails", dbConfig.GetConnection()))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            user = new User
                            {
                                //Id = reader.GetGuid(reader.GetOrdinal("UserId")),
                                Name = reader.GetString(reader.GetOrdinal("UserName")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Password = reader.GetString(reader.GetOrdinal("Password"))
                            };
                        }
                    }
                }
                return user;
            }
        }


        public async Task<bool> RegisterUser(User user)
        {
            await using (dbConfig)
            {
                await dbConfig.OpenAsync(); using (var command = new SqlCommand("RegisterUser", dbConfig.GetConnection()))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", user.Name);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0; // Return true if the user was successfully registered

                }
            }
        }
    }
}

