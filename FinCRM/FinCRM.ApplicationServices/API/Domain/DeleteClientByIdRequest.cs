using MediatR;
using System;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class DeleteClientByIdRequest : IRequest<DeleteClientByIdResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Source { get; set; }
        public int Age { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Note { get; set; }
    }
}
