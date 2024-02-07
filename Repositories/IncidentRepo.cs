using IncidentMgtSystem.API.DTOs;
using IncidentMgtSystem.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

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

        public bool UpdateIncidentComment(IncidentComments incidentComment)
        {
            var comment = _dbContext.tbl_IncidentComments.Where(c => c.IncId == incidentComment.IncId).FirstOrDefault();

            if(comment != null)
            {
                comment.Message = incidentComment.Message;
                return _dbContext.SaveChanges() > 0;
            }

            // Not Found
            return false;
        }

        public List<IncidentComments> GetAllComments(int incId)
        {
            var comments = _dbContext.tbl_IncidentComments.Where(c => c.IncId == incId).ToList();

            foreach (var c in comments)
            {
                c.User = _dbContext.tbl_User.Where(p => p.Id == c.AddedById).FirstOrDefault();
            }

            return comments;
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

        public IncidentMaster Delete(int id)
        {
            var result = _dbContext.tbl_IncidentMaster.Where(p => p.Id == id).FirstOrDefault();

            if(result != null)
            {
                _dbContext.tbl_IncidentMaster.Remove(result);
            }

            return result;
        }

        public IncidentMaster Update(IncidentUpdateApiRequest apiRequest)
        {
            var result = _dbContext.tbl_IncidentMaster.Where(p => p.Id == apiRequest.IncId).FirstOrDefault();
            
            if (result != null)
            {
                var incident = new IncidentMaster()
                {
                    Description = apiRequest.Description,
                    Symptoms = apiRequest.Symptoms,
                    TenantId = apiRequest.TenantId,
                    CityId = apiRequest.CityId,
                    Priority = apiRequest.Priority,
                    Urgency = apiRequest.Urgency,
                    Status = apiRequest.Status
                };

                _dbContext.tbl_IncidentMaster.Update(incident);
            }

            return result;
        }
    }
}
