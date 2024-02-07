using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentMgtSystem.API.Models
{
    public class IncidentComments
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int IncId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AddedById { get; set; }

        [ForeignKey("IncId")]
        public virtual IncidentMaster IncidentMaster { get; set; }

        [NotMapped]
        public User User { get; set; }
    }
}
