using Inlogic.DAL.Repositories;
using Inlogic.Pos.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlogic.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUsersData _userData;
        public UserService(IUsersData userData)
        {
            _userData = userData;
        }
        public async Task<Users> UserAuthentication(Login data)
        {
            return await _userData.getUser(data);
        }
        public async Task<Users> UserRegistration(Users data)
        {
            return await _userData.Registration(data);
        }
    }
}
