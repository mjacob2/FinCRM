namespace FinCRM.ApplicationServices.API.Handlers
{
    using AutoMapper;
    using FinCRM.ApplicationServices.API.Domain.Models;
    using FinCRM.ApplicationServices.API.Domain;
    using FinCRM.DataAccess.CQRS;
    using FinCRM.DataAccess.CQRS.Commands;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using FinCRM.DataAccess.Entities;

    public class AddApplicationHandler : IRequestHandler<AddApplicationRequest, AddApplicationResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddApplicationHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddApplicationResponse> Handle(AddApplicationRequest request, CancellationToken cancellationToken)
        {

            //mamy w kontekście aktualnie zalogowanego Usera
            var loggedUserRole = request.LoggedUserRole;
            var loggedUserId = request.LoggedUserId;

            var application = this.mapper.Map<DataAccess.Entities.Application>(request);
            var command = new AddApplicationCommand() { Parameter = application };
            var applicationFromDb = await this.commandExecutor.Execute(command);
            return new AddApplicationResponse()
            {
                Data = this.mapper.Map<Domain.Models.Application>(applicationFromDb)
            };
        }
    }
}
