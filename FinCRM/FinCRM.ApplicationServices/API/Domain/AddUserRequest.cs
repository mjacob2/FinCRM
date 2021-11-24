using MediatR;
using System;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; } // To będzie e-mail
    public string Password { get; set; }
    public string Role { get; set; }
    public string Salt;
    public DateTime CreatedDate { get; set; }

    }
}