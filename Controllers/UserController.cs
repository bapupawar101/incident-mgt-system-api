using IncidentMgtSystem.API.DTOs;
using IncidentMgtSystem.API.Models;
using IncidentMgtSystem.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace IncidentMgtSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;
        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        //[Authorize]
        [HttpPost]
        [Route("AddUser")]
        public bool AddUser([FromBody] AddUserRequestDto requestDto)
        {
            var result = _userService.AddUser(requestDto);
            return result;
        }

        //[Authorize]
        [HttpGet]
        [Route("GetAllUsers")]
        public List<User> GetAllUsers()
        {
            var result = _userService.GetAll();
            return result;
        }
    }
}
