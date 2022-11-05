using Inlogic.DAL.Context;
using Inlogic.Pos.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inlogic.DAL.Repositories
{
    public class UsersData : IUsersData
    {
        private readonly ApplicationDbContext _datacontext;
        public UsersData(ApplicationDbContext datacontext)
        {
            _datacontext = datacontext;
        }
        public async Task<Users> getUser(Login data)
        {
            return await _datacontext.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == data.UserName.ToLower() && x.Password.ToLower() == data.Password.ToLower()) ?? new Users();
        }
        public async Task<Users> Registration(Users data)
        {
            
            var User =  await _datacontext.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == data.UserName.ToLower() && x.Password.ToLower() == data.Password.ToLower()) ?? new Users();
            if (User.UserName == null && User.Password == null)
            {
                data.id = Guid.NewGuid().ToString();
                data.role = "User";

                await _datacontext.Users.AddAsync(data);
                await _datacontext.SaveChangesAsync();
                return data;
            }
            return /*await*/ new Users();
        }

    }
}
