using Inlogic.Pos.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace Inlogic.PosSolution.JwtTokenGenerator
{
    public interface IJwtTokenGenrator
    {
        JwtSecurityToken CreateJwtToken(Users userCheck);
    }
}