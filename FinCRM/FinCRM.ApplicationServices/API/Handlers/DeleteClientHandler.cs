using AutoMapper;
using FinCRM.ApplicationServices.API.Domain;
using FinCRM.DataAccess.CQRS;
using FinCRM.DataAccess.CQRS.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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

            //mamy w kontekście aktualnie zalogowanego Usera
            var loggedUserRole = request.LoggedUserRole;
            var loggedUserId = request.LoggedUserId;

            var client = this.mapper.Map<DataAccess.Entities.Client>(request);
            var command = new DeleteClientCommand() { Parameter = client };
            var clientFromDb = await this.commandExecutor.Execute(command);


            return new DeleteClientByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Clients>(clientFromDb)
            };
        }
    }
}