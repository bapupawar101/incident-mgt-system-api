namespace IncidentMgtSystem.API.DTOs
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse : ResponseBase
    {
        public string JwtToken { get; set; }
    }
}
