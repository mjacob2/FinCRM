using MediatR;
using System;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class ValidateUserRequest : RequestBase, IRequest<ValidateUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string Salt;
    }
}
