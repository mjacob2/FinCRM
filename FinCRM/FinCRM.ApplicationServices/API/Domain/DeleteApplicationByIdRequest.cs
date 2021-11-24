using MediatR;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class DeleteApplicationByIdRequest : IRequest<DeleteApplicationByIdResponse>
    {
        public int Id { get; set; }
    }
}
