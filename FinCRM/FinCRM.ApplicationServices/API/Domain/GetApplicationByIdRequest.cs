using MediatR;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class GetApplicationByIdRequest : IRequest<GetApplicationByIdResponse>
    {
        public int ApplicationId { get; set; }
    }
}
