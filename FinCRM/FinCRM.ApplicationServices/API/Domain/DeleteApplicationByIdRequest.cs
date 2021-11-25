using MediatR;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class DeleteApplicationByIdRequest : RequestBase, IRequest<DeleteApplicationByIdResponse>
    {
        public int Id { get; set; }
    }
}
