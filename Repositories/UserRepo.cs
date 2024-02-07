using IncidentMgtSystem.API.DTOs;
using IncidentMgtSystem.API.Enums;
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
            _dbContext.SaveChanges();

            UserLogin userLogin = new UserLogin()
            {
                UserName = requestDto.Username,
                Password = requestDto.Password,
                IsActive = true,
                UserId = user.Id
            };

            _dbContext.tbl_UserLogin.Add(userLogin);

            foreach (var roleId in requestDto.Roles)
            {
                UserRoles userRole = new UserRoles()
                {
                    RoleId = (int)roleId,
                    UserId = user.Id
                };

                _dbContext.tbl_UserRoles.Add(userRole);
            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<User> GetAllUsers()
        {
            var result = _dbContext.tbl_User.ToList();
            return result;
        }

    }
}
