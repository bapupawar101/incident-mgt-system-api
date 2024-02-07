using IncidentMgtSystem.API.Enums;
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

        public List<UserRole> GetUserRoles(int userId)
        {
            var roles = _dbContext.tbl_UserRoles.Where(p => p.UserId == userId).Select(p => (UserRole)p.RoleId).ToList();
            return roles;
        }
    }
}
