using IncidentMgtSystem.API.Enums;

namespace IncidentMgtSystem.API.DTOs
{
    public class AddUserRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}
