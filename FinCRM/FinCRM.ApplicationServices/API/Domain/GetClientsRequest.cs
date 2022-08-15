using MediatR;

namespace FinCRM.ApplicationServices.API.Domain
{

    public class GetClientsRequest : RequestBase, IRequest<GetClientsResponse>
    {
    }
}
