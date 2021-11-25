using MediatR;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class DeleteClientByIdRequest : RequestBase, IRequest<DeleteClientByIdResponse>
    {
        public int Id { get; set; }
    }
}
