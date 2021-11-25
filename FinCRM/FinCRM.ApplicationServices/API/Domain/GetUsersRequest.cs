using MediatR;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class GetUsersRequest : RequestBase, IRequest<GetUsersResponse>
    {

    }
}