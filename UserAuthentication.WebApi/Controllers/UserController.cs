using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAuthentication.WebApi.Models;
using UserAuthentication.WebApi.Services;

namespace UserAuthentication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices services;
        public UserController(UserServices  services) 
        { 
            this.services = services;
        }

        [HttpGet]
        [Route("")]
        public async Task<User> GetUserDetails(string email,string password)
        {

        }


        [HttpPost]
        [Route("add")]
        public async Task<User> RegisterNewuser([FromForm]UserRequest user)
        {

        }
    }
}
