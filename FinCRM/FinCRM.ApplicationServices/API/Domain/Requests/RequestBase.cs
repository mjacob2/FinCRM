namespace FinCRM.ApplicationServices.API.Domain.Requests
{
    public class RequestBase
    {
        public string? LoggedUserRole { get; set; }
        public string? LoggedUserId { get; set; }
    }
}
