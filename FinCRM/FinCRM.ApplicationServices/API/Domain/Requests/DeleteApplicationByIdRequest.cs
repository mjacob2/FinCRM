using FinCRM.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace FinCRM.ApplicationServices.API.Domain.Requests
{
    public class DeleteApplicationByIdRequest : RequestBase, IRequest<DeleteApplicationByIdResponse>
    {
        public int Id { get; set; }
    }
}
