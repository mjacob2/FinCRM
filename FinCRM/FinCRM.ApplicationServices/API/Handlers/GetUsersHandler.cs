using AutoMapper;
using FinCRM.ApplicationServices.API.Domain;
using FinCRM.DataAccess;
using FinCRM.DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinCRM.ApplicationServices.API.Handlers
{
    internal class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {

        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;
        public GetUsersHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }


        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {   
            //mamy w kontekście aktualnie zalogowanego Usera
            var loggedUserRole = request.LoggedUserRole;
            var loggedUserId = request.LoggedUserId;


            //Wyciągamy dane z Executora
            var query = new GetUsersQuery(); // Tworzymy Query narazie bez parametrów w {}
            var users = await this.queryExecutor.Execute(query);

            //Tu używamy AutoMappera
            var mappedUsers = this.mapper.Map<List<Domain.Models.User>>(users);

            /*            var domainClients = clients.Select(x => new Domain.Models.Client()
                        {
                            // Tu obsługujemy wszystkie dane, które zawarliśmy w modelu
                            Id = x.Id,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            PhoneNumber = x.PhoneNumber,
                            Email = x.Email,
                        });*/
            var response = new GetUsersResponse()
            {
                Data = mappedUsers
            };
            return response;
        }
    }
}
