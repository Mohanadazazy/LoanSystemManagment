using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(LoginDto login)
        {
           var userResult = await serviceManager.AuthService.SignInAsync(login);
            return Ok(userResult);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(RegisterDto register)
        {
            var userResult  = await serviceManager.AuthService.SignUpAsync(register);
            return Ok(userResult);
        }
        [HttpGet("GetAllUser/{userId}")]
        public async Task<IActionResult> GetAllUser(string userId)
        {
           var usersResult = await serviceManager.AuthService.GetAllUsersExceptOneAsync(userId);
            return Ok(usersResult);
        }
    }
}
