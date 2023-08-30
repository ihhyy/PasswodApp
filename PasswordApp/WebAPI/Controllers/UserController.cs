using BL.Interfaces;
using BL.Models;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserMethods methods;

        public UserController(IConfiguration config, IUserMethods _methods)
        {
            methods = _methods;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser(UserLogin request)
        {
            return  methods.RegisterUser(request);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginUser(UserLogin request)
        {
            return await methods.LoginUserAsync(request);
        }
    }
}
