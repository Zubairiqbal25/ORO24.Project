using Microsoft.AspNetCore.Mvc;
using Inlogic.Services.User;
using Inlogic.Pos.Entities;
using System.IdentityModel.Tokens.Jwt;
using Inlogic.PosSolution.JwtTokenGenerator;
using Microsoft.AspNetCore.Authorization;

namespace Inlogic.PosSolution.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenGenrator _jwtTokenGenrator;

        public UsersController(IUserService userService, IJwtTokenGenrator jwtTokenGenrator)
        {
            _userService = userService;
            _jwtTokenGenrator = jwtTokenGenrator;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration(Users data)
        {
            if (data != null && data.UserName != null && data.Password != null)
            {
                var Register = await _userService.UserRegistration(data);
                if (Register != null && Register.UserName != null && Register.Password != null)
                {
                    return Ok(new JwtSecurityTokenHandler().WriteToken(_jwtTokenGenrator.CreateJwtToken(Register)));
                }
                else
                {
                    return NotFound("No User found");
                }
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }

        }
        [HttpPost]
        [Route("LogIn")]
        public async Task<IActionResult> LogIn(Login data)
        {
            if (data != null && data.UserName != null && data.Password != null)
            {
                var userCheck = await _userService.UserAuthentication(data);
                if (userCheck != null && userCheck.UserName != null && userCheck.Password != null)
                {
                    return Ok(new JwtSecurityTokenHandler().WriteToken(_jwtTokenGenrator.CreateJwtToken(userCheck)));
                }
                else
                {
                    return NotFound("No User found");
                }
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }

        }
    }
}
