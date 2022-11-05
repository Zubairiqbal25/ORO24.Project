using Inlogic.Pos.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Inlogic.PosSolution.JwtTokenGenerator
{
    public class JwtTokenGenrator : IJwtTokenGenrator
    {

        private readonly IConfiguration _configuration;
        public JwtTokenGenrator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public JwtSecurityToken CreateJwtToken(Users userCheck)
        {
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

            var claims = new[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", userCheck.id.ToString()),
                        new Claim("username", userCheck.UserName),
                        new Claim("password", userCheck.Password),
                        new Claim("role", userCheck.role.ToString())
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            return new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(20),
                    signingCredentials: signIn
                );

            // return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
