using FinCRM.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace FinCRM.ApplicationServices.API.Domain.Requests
{

    public class GetApplicationsRequest : RequestBase, IRequest<GetApplicationsResponse>
    {

    }
}
