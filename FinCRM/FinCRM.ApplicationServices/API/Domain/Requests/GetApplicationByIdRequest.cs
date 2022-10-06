using FinCRM.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace FinCRM.ApplicationServices.API.Domain.Requests
{
    public class GetApplicationByIdRequest : RequestBase, IRequest<GetApplicationByIdResponse>
    {
        public int ApplicationId { get; set; }
    }
}
