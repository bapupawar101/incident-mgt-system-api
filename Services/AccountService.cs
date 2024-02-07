using IncidentMgtSystem.API.DTOs;
using IncidentMgtSystem.API.Models;
using IncidentMgtSystem.API.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IncidentMgtSystem.API.Services
{
    public class AccountService
    {
        public readonly AccountRepo _accountRepo;
        public readonly IConfiguration _configuration;
        public AccountService(AccountRepo accountRepo, IConfiguration configuration) {
            _accountRepo = accountRepo;
            _configuration = configuration;
        }

        public LoginResponse ValidateLoginDetails(LoginRequest loginRequest)
        {
            var user = _accountRepo.ValidateLoginDetails(loginRequest.UserName, loginRequest.Password);
            LoginResponse response = new LoginResponse();
            if (user == null)
            {
                response.Success = false;
                response.ErrorMessage = "Invalid username and password";
            }
            else
            {
                user.User.Roles = _accountRepo.GetUserRoles(user.UserId);
                response.User = user.User;

                var token = GenerateToken(user.User);
                response.JwtToken = token;
                response.Success = true;
            }

            return response;
        }

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var crendentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("Id", user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiresInMinutes"])),
                signingCredentials: crendentials
            );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
