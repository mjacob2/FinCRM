using MediatR;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class GetClientByIdRequest : RequestBase, IRequest<GetClientByIdResponse>
    {
        public int ClientId {  get; set; }
    }
}
