using Inlogic.Pos.Entities;

namespace Inlogic.Services.User
{
    public interface IUserService
    {
        Task<Users> UserAuthentication(Login data);
        Task<Users> UserRegistration(Users data);
    }
}