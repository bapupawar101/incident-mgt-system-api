using IncidentMgtSystem.API.DTOs;
using IncidentMgtSystem.API.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace IncidentMgtSystem.API.Repositories
{
    public class UserRepo
    {
        public readonly IncDbContext _dbContext;
        public UserRepo(IncDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddUser(AddUserRequestDto requestDto)
        {
            User user = new User()
            {
                FirstName = requestDto.FirstName,
                LastName = requestDto.LastName,
                MobileNo = requestDto.MobileNo,
                Email = requestDto.Email,
                CreatedDateTime = DateTime.Now
            };

            _dbContext.tbl_User.Add(user);

            return _dbContext.SaveChanges() > 0;
        }

        public List<User> GetAllUsers()
        {
            var result = _dbContext.tbl_User.ToList();
            return result;
        }

    }
}
