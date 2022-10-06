using FinCRM.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace FinCRM.ApplicationServices.API.Domain.Requests
{
    public class GetClientByIdRequest : RequestBase, IRequest<GetClientByIdResponse>
    {
        public int ClientId {  get; set; }
    }
}
