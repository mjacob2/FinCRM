using FinCRM.ApplicationServices.API.Domain;
using FinCRM.DataAccess;
using FinCRM.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FinCRM.DataAccess.CQRS.Queries;
using AutoMapper;
using System.Collections.Generic;
using FinCRM.ApplicationServices.API.Domain.Requests;
using FinCRM.ApplicationServices.API.Domain.Responses;

namespace FinCRM.ApplicationServices.API.Handlers
{
    public class GetApplicationsHandler : IRequestHandler<GetApplicationsRequest, GetApplicationsResponse>
    {

        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetApplicationsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }


        public async Task<GetApplicationsResponse> Handle(GetApplicationsRequest request, CancellationToken cancellationToken)
        {
            var loggedUserRole = request.LoggedUserRole;
            var loggedUserId = request.LoggedUserId;

            var query = new GetApplicationtsQuery();
            var applications = await this.queryExecutor.Execute(query);
            var mappedApplications = this.mapper.Map<List<Domain.Models.Applications>>(applications);

            var response = new GetApplicationsResponse()
            {
                Data = mappedApplications
            };
            return response;
        }
    }
}
