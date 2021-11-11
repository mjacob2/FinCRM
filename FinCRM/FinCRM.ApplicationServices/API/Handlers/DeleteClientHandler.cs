using AutoMapper;
using FinCRM.ApplicationServices.API.Domain.Models;
using FinCRM.ApplicationServices.API.Domain;
using FinCRM.DataAccess.CQRS;
using FinCRM.DataAccess.CQRS.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FinCRM.DataAccess.Entities;
using System;

namespace FinCRM.ApplicationServices.API.Handlers
{
    class DeleteClientHandler : IRequestHandler<DeleteClientByIdRequest, DeleteClientByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteClientHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteClientByIdResponse> Handle(DeleteClientByIdRequest request, CancellationToken cancellationToken)
        {

            var client = this.mapper.Map<DataAccess.Entities.Client>(request);
            var command = new DeleteClientCommand() { Parameter = client };
            var clientFromDb = await this.commandExecutor.Execute(command);


            return new DeleteClientByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Client>(clientFromDb)
            };
        }
    }
}