﻿using AutoMapper;
using FinCRM.ApplicationServices.API.Domain.Models;
using FinCRM.ApplicationServices.API.Domain;
using FinCRM.DataAccess.CQRS;
using FinCRM.DataAccess.CQRS.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FinCRM.DataAccess.Entities;

namespace FinCRM.ApplicationServices.API.Handlers
{
    class UpdateClientByIdHandler : IRequestHandler<UpdateClientByIdRequest, UpdateClientByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public UpdateClientByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<UpdateClientByIdResponse> Handle(UpdateClientByIdRequest request, CancellationToken cancellationToken)
        {

            var client = this.mapper.Map<DataAccess.Entities.Client>(request);
            var command = new UpdateClientCommand() { Parameter = client };
            var clientFromDb = await this.commandExecutor.Execute(command);
            return new UpdateClientByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Client>(clientFromDb)
            };
        }
    }
}