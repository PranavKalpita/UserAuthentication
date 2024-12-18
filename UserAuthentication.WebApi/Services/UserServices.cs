using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<User> GetuserAsync(string email,string password)
        {
            var res = await userRepository.GetUser(email, password);
            return res;
        }

        public async Task<bool> RegisteruserAsync(UserRequest newuser) 
        { 
            var user = new User()
            { Id = Guid.NewGuid(),
                Name = newuser.Name, 
                Email = newuser.Email,
                Password = newuser.Password, };
            return await userRepository.RegisterUser(user);
        }
    }
}
