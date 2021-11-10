using MediatR;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class GetClientByIdRequest : IRequest<GetClientByIdResponse>
    {
        public int ClientId {  get; set; }
    }
}
