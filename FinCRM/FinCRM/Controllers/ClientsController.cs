namespace FinCRM.Controllers
{
    using FinCRM.ApplicationServices.API.Domain;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;


    [Authorize]
    [ApiController]
    [Route("[controller]")]


    public class ClientsController : ApiControllerBase
        
    {

        public ClientsController(IMediator mediator) : base(mediator)
        {
        }


        
        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllClients([FromQuery] GetClientsRequest request)
        {
            return this.HandleRequest<GetClientsRequest, GetClientsResponse>(request);
        }


        [HttpGet]
        [Route("{clientId}")]
        public Task<IActionResult> GetById([FromRoute] int clientId)
        {
            var request = new GetClientByIdRequest()
            {
                ClientId = clientId
            };

            return this.HandleRequest<GetClientByIdRequest, GetClientByIdResponse>(request);
        }


        [HttpPut]
        [Route("{clientId}")]
        public Task<IActionResult> UpdateById([FromRoute] int clientId, [FromBody] UpdateClientByIdRequest request)
        {
            request.Id = clientId;

            return this.HandleRequest<UpdateClientByIdRequest, UpdateClientByIdResponse>(request);
        }


        [HttpDelete]
        [Route("{clientId}")]
        public Task<IActionResult> DeleteById([FromRoute] int clientId)
        {
            var request = new DeleteClientByIdRequest()
            {
                Id = clientId
            };

            return this.HandleRequest<DeleteClientByIdRequest, DeleteClientByIdResponse>(request);
        }


        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddClient([FromBody] AddClientRequest request)
        {
            return this.HandleRequest<AddClientRequest, AddClientResponse>(request);

        }
    }
}
