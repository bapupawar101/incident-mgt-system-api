using IncidentMgtSystem.API.DTOs;
using IncidentMgtSystem.API.Models;
using IncidentMgtSystem.API.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IncidentMgtSystem.API.Services
{
    public class IncidentService
    {
        public readonly IncidentRepo _incRepo;
        public readonly IConfiguration _configuration;
        public IncidentService(IncidentRepo incRepo, IConfiguration configuration)
        {
            _incRepo = incRepo;
            _configuration = configuration;
        }

        public IncidentSaveAPIResponse SaveIncident(IncidentSaveAPIRequest request, int userId)
        {
            IncidentMaster incidentMaster = new IncidentMaster()
            {
                CityId = request.CityId,
                CreatedDate = DateTime.Now,
                Description = request.Description,
                Priority = request.Priority,
                RequesterId = userId,
                Status = Enums.IncidentStatus.New,
                Symptoms = request.Symptoms,
                TenantId = request.TenantId,
                Urgency = request.Urgency
            };

            var result = _incRepo.SaveIncident(incidentMaster);
            IncidentSaveAPIResponse response = new IncidentSaveAPIResponse();
            if (!result)
            {
                response.Success = false;
                response.ErrorMessage = "Some error occured at server side.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public List<IncidentMaster> GetAll()
        {
            var result = _incRepo.GetAll();
            
            return result;
        }

        public IncidentMaster GetById(int id)
        {
            var result = _incRepo.GetById(id);

            return result;
        }

        public IncidentMaster Delete(int id)
        {
            var result = _incRepo.Delete(id);

            return result;
        }

        public IncidentMaster Update(IncidentUpdateApiRequest apiRequest)
        {
            var result = _incRepo.Update(apiRequest);

            return result;
        }

        public IncidentCommentSaveAPIResponse SaveIncidentComment(IncidentCommentSaveAPIRequest request, int userId)
        {
            IncidentComments incidentComment = new IncidentComments()
            {
                IncId = request.IncId,
                Message = request.Message,
                CreatedDate = DateTime.Now,
                AddedById = userId
            };

            var result = _incRepo.SaveIncidentComment(incidentComment);
            IncidentCommentSaveAPIResponse response = new IncidentCommentSaveAPIResponse();
            if (!result)
            {
                response.Success = false;
                response.ErrorMessage = "Some error occured at server side.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public IncidentCommentUpdateAPIResponse UpdateIncidentComment(IncidentCommentUpdateApiRequest request)
        {
            IncidentComments incidentComment = new IncidentComments()
            {
                Message = request.Message,
                IncId = request.IncId
            };

            var result = _incRepo.UpdateIncidentComment(incidentComment);
            IncidentCommentUpdateAPIResponse response = new IncidentCommentUpdateAPIResponse();
            if (!result)
            {
                response.Success = false;
                response.ErrorMessage = "Some error occured at server side.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public List<IncidentComments> GetAllComments(int incId)
        {
            var response = _incRepo.GetAllComments(incId);
            return response;
        }

    }
}
