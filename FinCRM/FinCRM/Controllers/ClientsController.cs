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


    public class ClientsController : ApiControllerBase // Już nie dziedziczymy po ControllerBase a po ApiControlerBase, którą sami stworzyliśmy
    {

        //private readonly IMediator mediator; //Tego też nie potrzebujemy już, odkąd mamy klasę bazową ApiControllerBase

        //Constructor
        public ClientsController(IMediator mediator) : base(mediator)//przekazujemy jeszcze w konstruktorze do klasy bazowej mediatora
        {
            // Tu będziemy korzystać z Mediatr
            //this.mediator = mediator;  // ten mediator stąd wylatuje, bo jest już w klasie bazowej
        }


        // Znów robimy metodę GET na wszystko, ale nie będziemy już wołać całego repozytorium,
        // tylko wywołamy nasze Request i Response i obsłużymy je ApplicationService

        
        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllClients([FromQuery] GetClientsRequest request)
        {
            return this.HandleRequest<GetClientsRequest, GetClientsResponse>(request);
        }


        // Tu robimy GETa po konkretnym Id
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


        // Tu robimy PUTa po konkretnym Id
        [HttpPut]
        [Route("{clientId}")]
        public Task<IActionResult> UpdateById([FromRoute] int clientId, [FromBody] UpdateClientByIdRequest request)
        {
            request.Id = clientId;

            return this.HandleRequest<UpdateClientByIdRequest, UpdateClientByIdResponse>(request);
        }


        // Tu robimy DELETa po konkretnym Id
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


        //Robimy teraz metodę POST do dodawania do bazy
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddClient([FromBody] AddClientRequest request)
        {
            // Tu wywołujemy klasę bazową ApiControllerBase 
            return this.HandleRequest<AddClientRequest, AddClientResponse>(request);


        /*    //Sprawdzamy, czy ModelState - czyli to co nam przyszło, jest !NiePrawidłowe
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("ojoj bardzo niedobrze się stanęło");
            }
            var response = await this.mediator.Send(request);
            return this.Ok(response);*/
        }
    }
}
