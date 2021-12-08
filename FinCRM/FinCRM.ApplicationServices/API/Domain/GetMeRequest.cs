using MediatR;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class GetMeRequest : RequestBase, IRequest<GetMeResponse>
    {
        public int UserId;
    }
}
