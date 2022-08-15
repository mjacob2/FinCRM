using AutoMapper;
using FinCRM.ApplicationServices.API.Domain;
using FinCRM.DataAccess;
using FinCRM.DataAccess.CQRS;
using FinCRM.DataAccess.CQRS.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinCRM.ApplicationServices.API.Handlers
{
    class UpdateClientByIdHandler : IRequestHandler<UpdateClientByIdRequest, UpdateClientByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        //private readonly IQueryExecutor queryExecutor;


        public UpdateClientByIdHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            //this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateClientByIdResponse> Handle(UpdateClientByIdRequest request, CancellationToken cancellationToken)
        {

            var loggedUserRole = request.LoggedUserRole;
            var loggedUserId = request.LoggedUserId;

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