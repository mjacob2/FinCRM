using MediatR;

namespace FinCRM.ApplicationServices.API.Domain
{

    public class GetApplicationsRequest : RequestBase, IRequest<GetApplicationsResponse>
    {

    }
}
