using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentMgtSystem.API.Models
{
    public class CityMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }

        [ForeignKey("StateId")]
        public virtual StateMaster State { get; set; }
    }
}
