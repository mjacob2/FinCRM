using FinCRM.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace FinCRM.ApplicationServices.API.Domain.Requests
{
    public class ValidateUserRequest : RequestBase, IRequest<ValidateUserResponse>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }

        public string? Salt;
    }
}
