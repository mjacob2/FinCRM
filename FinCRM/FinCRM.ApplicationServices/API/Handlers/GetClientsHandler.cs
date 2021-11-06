using FinCRM.ApplicationServices.API.Domain;
using FinCRM.DataAccess;
using FinCRM.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FinCRM.ApplicationServices.API.Handlers
{
    public class GetClientsHandler : IRequestHandler<GetClientsRequest, GetClientsResponse>
    {

        private readonly IRepository<Client> clientRepository;
        public GetClientsHandler(IRepository<DataAccess.Entities.Client> clientRepository)
        {
            this.clientRepository = clientRepository;
        }


        public Task<GetClientsResponse> Handle(GetClientsRequest request, CancellationToken cancellationToken)
        {
            var clients = this.clientRepository.GetAll();

            var domainClients = clients.Select(x => new Domain.Models.Client()
            {
                // Tu obsługujemy wszystkie dane, które zawarliśmy w modelu
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,


            });

            var response = new GetClientsResponse()
            {
                Data = domainClients.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
