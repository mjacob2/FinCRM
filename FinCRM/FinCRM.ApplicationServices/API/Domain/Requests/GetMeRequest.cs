using FinCRM.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace FinCRM.ApplicationServices.API.Domain.Requests
{
    public class GetMeRequest : RequestBase, IRequest<GetMeResponse>
    {
        public int UserId;
    }
}
