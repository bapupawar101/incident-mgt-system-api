using IncidentMgtSystem.API.Models;

namespace IncidentMgtSystem.API.Repositories
{
    public class IncidentRepo
    {
        public readonly IncDbContext _dbContext;
        public IncidentRepo(IncDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool SaveIncident(IncidentMaster incidentMaster)
        {
            _dbContext.tbl_IncidentMaster.Add(incidentMaster);
            return _dbContext.SaveChanges() > 0;
        }

        public bool SaveIncidentComment(IncidentComments incidentComment)
        {
            _dbContext.tbl_IncidentComments.Add(incidentComment);
            return _dbContext.SaveChanges() > 0;
        }

        public List<IncidentMaster> GetAll()
        {
            var result = _dbContext.tbl_IncidentMaster.ToList();
            return result;
        }

        public IncidentMaster GetById(int id)
        {
            var result = _dbContext.tbl_IncidentMaster.Where(p => p.Id == id).FirstOrDefault();
            return result;
        }
    }
}
