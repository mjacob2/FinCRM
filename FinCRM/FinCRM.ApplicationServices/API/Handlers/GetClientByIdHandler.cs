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
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdRequest, GetClientByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

            public GetClientByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
            {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            }

        public async Task<GetClientByIdResponse> Handle(GetClientByIdRequest request, CancellationToken cancellation)
        {
            var query = new GetClientQuery()
            {
                ClientId = request.ClientId
            };
            var client = await this.queryExecutor.Execute(query);
            var mappedClient = this.mapper.Map<Domain.Models.Client>(client);
            var response = new GetClientByIdResponse()
            {
                Data = mappedClient
            };
            return response;
        }
    }
}
