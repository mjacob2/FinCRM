﻿using AutoMapper;
using FinCRM.ApplicationServices.API.Domain;
using FinCRM.DataAccess;
using FinCRM.DataAccess.CQRS;
using FinCRM.DataAccess.CQRS.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FinCRM.ApplicationServices.API.Domain.Requests;
using FinCRM.ApplicationServices.API.Domain.Responses;

namespace FinCRM.ApplicationServices.API.Handlers
{
    public class UpdateApplicationByIdHandler : IRequestHandler<UpdateApplicationByIdRequest, UpdateApplicationByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        //private readonly IQueryExecutor queryExecutor;


        public UpdateApplicationByIdHandler (ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            //this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateApplicationByIdResponse> Handle(UpdateApplicationByIdRequest request, CancellationToken cancellationToken)
        {

            var loggedUserRole = request.LoggedUserRole;
            var loggedUserId = request.LoggedUserId;

            var application = this.mapper.Map<DataAccess.Entities.Application>(request);
            var command = new UpdateApplicationCommand() { Parameter = application };
            var applicationFromDb = await this.commandExecutor.Execute(command);
            return new UpdateApplicationByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Application>(applicationFromDb)
            };
        }
    }
}