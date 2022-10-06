using FinCRM.ApplicationServices.API.Domain.Requests;
using FinCRM.ApplicationServices.API.Domain.Responses;

namespace FinCRM.Controllers
{
    using FinCRM.ApplicationServices.API.Domain;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;


    //[Authorize]
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
        public Task<IActionResult> GetAllUSers([FromQuery] GetUsersRequest request)
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddUSer([FromBody] AddUserRequest request)
        {
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);


        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public Task<IActionResult> Post([FromBody] ValidateUserRequest request)
        {
            return this.HandleRequest<ValidateUserRequest, ValidateUserResponse>(request);
        }
       
        [HttpGet]
        [Route("me")]
        public Task<IActionResult> GetMe([FromQuery] GetMeRequest request)
        {
            return this.HandleRequest<GetMeRequest, GetMeResponse>(request);
        }


    }
}
