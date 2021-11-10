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
    class GetApplicationByIdHandler : IRequestHandler<GetApplicationByIdRequest, GetApplicationByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetApplicationByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetApplicationByIdResponse> Handle(GetApplicationByIdRequest request, CancellationToken cancellation)
        {
            var query = new GetApplicationQuery()
            {
                ApplicationId = request.ApplicationId
            };
            var application = await this.queryExecutor.Execute(query);
            var mappedApplication = this.mapper.Map<Domain.Models.Application>(application);
            var response = new GetApplicationByIdResponse()
            {
                Data = mappedApplication
            };
            return response;
        }
    }
}