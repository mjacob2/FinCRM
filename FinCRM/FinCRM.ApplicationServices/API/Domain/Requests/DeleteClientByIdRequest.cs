using FinCRM.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace FinCRM.ApplicationServices.API.Domain.Requests
{
    public class DeleteClientByIdRequest : RequestBase, IRequest<DeleteClientByIdResponse>
    {
        public int Id { get; set; }
    }
}
