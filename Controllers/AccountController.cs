using IncidentMgtSystem.API.DTOs;
using IncidentMgtSystem.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace IncidentMgtSystem.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly AccountService _accountService;
    public AccountController(ILogger<AccountController> logger,AccountService accountService)
    {
        _logger = logger;
        _accountService = accountService;
    }

    [HttpPost(Name = "Login")]
    public LoginResponse Login([FromBody] LoginRequest loginRequest)
    {
        LoginResponse response = _accountService.ValidateLoginDetails(loginRequest);
        return response;
    }
}
