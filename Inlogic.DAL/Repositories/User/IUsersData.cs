using Inlogic.Pos.Entities;

namespace Inlogic.DAL.Repositories
{
    public interface IUsersData
    {
        Task<Users> getUser(Login data);
        Task<Users> Registration(Users data);
    }
}