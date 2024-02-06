using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentMgtSystem.API.Models
{
    public class StateMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual CountryMaster Country { get; set; }
    }
}
