using UserAuthentication.WebApi.Models;
using UserAuthentication.WebApi.Repository;

namespace UserAuthentication.WebApi.Services
{
    public class UserServices
    {
        private readonly UserRepository userRepository;
        public UserServices(UserRepository userRepository) 
        { 
            this.userRepository = userRepository;
        }
        public async Task<User> GetuserAsync()
        {

        }
    }
}
