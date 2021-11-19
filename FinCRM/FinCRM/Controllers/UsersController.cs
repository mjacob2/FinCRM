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
    public class UsersController : ApiControllerBase 
    {
        public UsersController(IMediator mediator) 
            : base(mediator)
        {
        }

        
        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAll([FromQuery] GetUsersRequest request)
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        //[HttpPost]
        //[AllowAnonymous]

    }
}
