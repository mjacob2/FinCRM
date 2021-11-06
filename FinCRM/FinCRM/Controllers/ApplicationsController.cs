namespace FinCRM.Controllers
{
    using FinCRM.ApplicationServices.API.Domain;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly IMediator mediator;

        //Constructor
        public ApplicationsController(IMediator mediator)
        {
            // Tu będziemy korzystać z Mediatr
            this.mediator = mediator;
        }


        // Znów robimy metodę GET na wszystko, ale nie będziemy już wołać całego repozytorium,
        // tylko wywołamy naze klacly Request i Response i obsłużymy je ApplicationService

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllApplications([FromQuery] GetApplicationsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);//Zwraca kod 200 czyli Ok
        }


    }
}
