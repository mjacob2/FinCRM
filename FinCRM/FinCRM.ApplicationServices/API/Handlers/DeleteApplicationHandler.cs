using AutoMapper;
using FinCRM.ApplicationServices.API.Domain;
using FinCRM.DataAccess.CQRS;
using FinCRM.DataAccess.CQRS.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinCRM.ApplicationServices.API.Handlers
{
    internal class DeleteApplicationHandler : IRequestHandler<DeleteApplicationByIdRequest, DeleteApplicationByIdResponse>
    {

    private readonly ICommandExecutor commandExecutor;
    private readonly IMapper mapper;

    public DeleteApplicationHandler(ICommandExecutor commandExecutor, IMapper mapper)
    {
        this.commandExecutor = commandExecutor;
        this.mapper = mapper;
    }

    public async Task<DeleteApplicationByIdResponse> Handle(DeleteApplicationByIdRequest request, CancellationToken cancellationToken)
    {

        var application = this.mapper.Map<DataAccess.Entities.Application>(request);
        var command = new DeleteApplicationCommand() { Parameter = application };
        var applicationFromDb = await this.commandExecutor.Execute(command);


        return new DeleteApplicationByIdResponse()
        {
            Data = this.mapper.Map<Domain.Models.Application>(applicationFromDb)
        };
    }
}
}