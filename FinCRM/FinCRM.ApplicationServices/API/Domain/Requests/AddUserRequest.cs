using System;
using FinCRM.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace FinCRM.ApplicationServices.API.Domain.Requests
{
    public class AddUserRequest : RequestBase, IRequest<AddUserResponse>
    {
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
    public string? Salt;
    public DateTime CreatedDate { get; set; }

    }
}