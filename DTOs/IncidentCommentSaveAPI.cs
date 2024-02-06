using IncidentMgtSystem.API.Enums;

namespace IncidentMgtSystem.API.DTOs
{
    public class IncidentCommentSaveAPIRequest
    {
        public string Message { get; set; }
        public int IncId { get; set; }
    }

    public class IncidentCommentSaveAPIResponse : ResponseBase
    {
    }
}
