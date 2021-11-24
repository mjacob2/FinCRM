using MediatR;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class DeleteClientByIdRequest : IRequest<DeleteClientByIdResponse>
    {
        public int Id { get; set; }
    }
}
