using AutoMapper;
using FinCRM.ApplicationServices.API.Domain;
using FinCRM.DataAccess;
using FinCRM.DataAccess.CQRS.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FinCRM.ApplicationServices.API.Domain.Requests;
using FinCRM.ApplicationServices.API.Domain.Responses;

namespace FinCRM.ApplicationServices.API.Handlers
{
    internal class GetMeHandler : IRequestHandler<GetMeRequest, GetMeResponse>
    {

        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;
        public GetMeHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }


        public async Task<GetMeResponse> Handle(GetMeRequest request, CancellationToken cancellationToken)
        {
            //mamy w kontekście aktualnie zalogowanego Usera
            var loggedUserRole = request.LoggedUserRole;
            var loggedUserId = request.LoggedUserId;


            //Wyciągamy dane z Executora
            var query = new GetMeQuery() // Tworzymy Query narazie bez parametrów w {}
            {
                UserId = Int32.Parse(loggedUserId)
            };
            var me = await this.queryExecutor.Execute(query);

            //Tu używamy AutoMappera
            var mappedMe = this.mapper.Map<Domain.Models.Me>(me);
            var response = new GetMeResponse()
            {
                Data = mappedMe
            };
            return response;
        }
    }
}