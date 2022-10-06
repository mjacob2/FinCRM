using FinCRM.ApplicationServices.API.Domain.Requests;
using FinCRM.ApplicationServices.API.Domain.Responses;

namespace FinCRM.ApplicationServices.API.Handlers
{
    using AutoMapper;
    using FinCRM.ApplicationServices.API.Domain;
    using FinCRM.DataAccess.CQRS;
    using FinCRM.DataAccess.CQRS.Commands;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;


    public class AddClientHandler : IRequestHandler<AddClientRequest, AddClientResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddClientHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddClientResponse> Handle(AddClientRequest request, CancellationToken cancellationToken)
        {

            var loggedUserRole = request.LoggedUserRole;
            var loggedUserId = request.LoggedUserId;

            var client = this.mapper.Map<DataAccess.Entities.Client>(request);
            var command = new AddClientCommand() { Parameter = client };
            var clientFromDb = await this.commandExecutor.Execute(command);
            return new AddClientResponse()
            {
                Data = this.mapper.Map<Domain.Models.Clients>(clientFromDb)
            };
        }
    }
}