using MediatR;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class GetApplicationByIdRequest : RequestBase, IRequest<GetApplicationByIdResponse>
    {
        public int ApplicationId { get; set; }
    }
}
