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
        public async Task<IActionResult> GetUserDetails(string email,string password)
        {
            if (email != null && password != null)
            {
                var entity = await services.GetuserAsync(email,password);
                if(entity == null) 
                    return NotFound("User Not Found");
                else 
                    return Ok(entity);
            }
            return BadRequest("Email id And Password Required");
        }


        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> RegisterNewuser([FromForm] UserRequest user)
        {
            var entity = await services.RegisteruserAsync(user);
            if (!entity)
                return BadRequest("Something went wrong");
            return Ok("User Registered Successfully");
        }
    }
}
