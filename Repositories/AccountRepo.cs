using IncidentMgtSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentMgtSystem.API.Repositories
{
    public class AccountRepo
    {
        public readonly IncDbContext _dbContext;
        public AccountRepo(IncDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserLogin ValidateLoginDetails(string username, string password)
        {
            UserLogin user = _dbContext.tbl_UserLogin.Where(p => p.UserName.Equals(username) && p.Password.Equals(password)).Include(p => p.User).FirstOrDefault();
            return user;
        }
    }
}
