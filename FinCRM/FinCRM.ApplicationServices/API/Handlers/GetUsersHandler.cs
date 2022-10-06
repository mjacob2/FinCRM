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
            var loggedUserRole = request.LoggedUserRole;
            var loggedUserId = request.LoggedUserId;


            var query = new GetUsersQuery(); // Tworzymy Query narazie bez parametrów w {}
            var users = await this.queryExecutor.Execute(query);

            var mappedUsers = this.mapper.Map<List<Domain.Models.User>>(users);

            /*            var domainClients = clients.Select(x => new Domain.Models.Client()
                        {
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
