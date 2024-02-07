using IncidentMgtSystem.API.DTOs;
using IncidentMgtSystem.API.Models;
using IncidentMgtSystem.API.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace IncidentMgtSystem.API.Services
{
    public class UserService
    {
        public readonly UserRepo _userRepo;
        public readonly IConfiguration _configuration;
        public UserService(UserRepo userRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _configuration = configuration;
        }

        public bool AddUser(AddUserRequestDto requestDto)
        {
            var result = _userRepo.AddUser(requestDto);
            return result;
        }

        public List<User> GetAll()
        {
            var result = _userRepo.GetAllUsers();
            return result;
        }

    }
}
