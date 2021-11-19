namespace FinCRM.Controllers
{
    using FinCRM.ApplicationServices.API.Domain;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class ApplicationsController : ApiControllerBase // Już nie dziedziczymy po ControllerBase a po ApiControlerBase, którą sami stworzyliśmy
    {
        //private readonly IMediator mediator; //Tego też nie potrzebujemy już, odkąd mamy klasę bazową ApiControllerBase

        //Constructor
        public ApplicationsController(IMediator mediator) : base(mediator)//przekazujemy jeszcze w konstruktorze do klasy bazowej mediatora
        {
            // Tu będziemy korzystać z Mediatr
            //this.mediator = mediator;  // ten mediator stąd wylatuje, bo jest już w klasie bazowej
        }


        // Znów robimy metodę GET na wszystko, ale nie będziemy już wołać całego repozytorium,
        // tylko wywołamy naze klacly Request i Response i obsłużymy je ApplicationService

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllApplications([FromQuery] GetApplicationsRequest request)
        {
            return this.HandleRequest<GetApplicationsRequest, GetApplicationsResponse>(request);
        }


        // Tu robimy GETa po konkretnym Id
        [HttpGet]
        [Route("applicationId")]
        public Task<IActionResult> GetById([FromQuery] int applicationId)
        {
            var request = new GetApplicationByIdRequest()
            {
                ApplicationId = applicationId
            };
            return this.HandleRequest<GetApplicationByIdRequest, GetApplicationByIdResponse>(request);
        }

        //Robimy teraz metodę POST do dodawania do bazy
        [HttpPost]
        [Route("")]
        // Żeby zadziałał AddApplicationRequest, musimy go stowrzyć w 
        public Task<IActionResult> AddApplication([FromBody] AddApplicationRequest request)
        {
            // Tu wywołujemy klasę bazową ApiControllerBase 
            return this.HandleRequest<AddApplicationRequest, AddApplicationResponse>(request);
        }
    }
}
