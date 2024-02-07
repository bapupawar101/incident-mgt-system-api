namespace IncidentMgtSystem.API.DTOs
{
    public class AddUserRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
