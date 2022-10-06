using AutoMapper;
using FinCRM.ApplicationServices.API.Domain;
using FinCRM.DataAccess;
using FinCRM.DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FinCRM.ApplicationServices.API.Domain.Requests;
using FinCRM.ApplicationServices.API.Domain.Responses;

namespace FinCRM.ApplicationServices.API.Handlers
{
    public class GetClientsHandler : IRequestHandler<GetClientsRequest, GetClientsResponse>
    {

        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;
        public GetClientsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }


        public async Task<GetClientsResponse> Handle(GetClientsRequest request, CancellationToken cancellationToken)
        {

            var loggedUserRole = request.LoggedUserRole;
            var loggedUserId = request.LoggedUserId;


            var query = new GetClientsQuery(); // Tworzymy Query narazie bez parametrów w {}
            var clients = await this.queryExecutor.Execute(query);

            var mappedClients = this.mapper.Map<List<Domain.Models.Clients>>(clients);

            /*            var domainClients = clients.Select(x => new Domain.Models.Client()
                        {
                            Id = x.Id,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            PhoneNumber = x.PhoneNumber,
                            Email = x.Email,
                        });*/
            var response = new GetClientsResponse()
            {
                Data = mappedClients
            };
            return response;
        }
    }
}
