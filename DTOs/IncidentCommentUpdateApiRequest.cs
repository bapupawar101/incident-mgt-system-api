namespace IncidentMgtSystem.API.DTOs
{
    public class IncidentCommentUpdateApiRequest
    {
        public string Message { get; set; }
        public int IncId { get; set; }
    }

    public class IncidentCommentUpdateAPIResponse : ResponseBase
    {
    }
}
