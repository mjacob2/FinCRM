namespace FinCRM.Controllers
{
    using FinCRM.ApplicationServices.API.Domain;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
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



        [HttpGet]
        [Route("{applicationId}")]
        public Task<IActionResult> GetById([FromRoute] int applicationId)
        {
            var request = new GetApplicationByIdRequest()
            {
                ApplicationId = applicationId
            };
            return this.HandleRequest<GetApplicationByIdRequest, GetApplicationByIdResponse>(request);
        }


        [HttpPut]
        [Route("{applicationId}")]
        public Task<IActionResult> UpdateById([FromRoute] int applicationId, [FromBody] UpdateApplicationByIdRequest request)
        {
            request.Id = applicationId;

            return this.HandleRequest<UpdateApplicationByIdRequest, UpdateApplicationByIdResponse>(request);
        }


        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddApplication([FromBody] AddApplicationRequest request)
        {
            // Tu wywołujemy klasę bazową ApiControllerBase 
            return this.HandleRequest<AddApplicationRequest, AddApplicationResponse>(request);
        }

        [HttpDelete]
        [Route("{applicaionId}")]
        public Task<IActionResult> DeleteById([FromRoute] int applicaionId)
        {
            var request = new DeleteApplicationByIdRequest()
            {
                Id = applicaionId
            };

            return this.HandleRequest<DeleteApplicationByIdRequest, DeleteApplicationByIdResponse>(request);
        }


    }
}
