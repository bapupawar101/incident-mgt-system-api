using IncidentMgtSystem.API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentMgtSystem.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public DateTime CreatedDateTime { get; set; }

        [NotMapped]
        public List<UserRole> Roles { get; set; }
    }
}
