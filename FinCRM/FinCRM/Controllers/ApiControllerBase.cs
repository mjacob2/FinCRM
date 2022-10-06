using FinCRM.ApplicationServices.API.Domain;
using FinCRM.ApplicationServices.API.Domain.Errors;
using FinCRM.ApplicationServices.API.ErrorHandling;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using FinCRM.ApplicationServices.API.Domain.Requests;

namespace FinCRM.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator mediator;
        protected ApiControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
        }
        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : RequestBase, IRequest<TResponse>
            where TResponse : ErrorResponseBase

        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(
                    this.ModelState
                        .Where(x => x.Value.Errors.Any())// Actual errors are in Value.Error
                        .Select(x => new { property = x.Key, errors = x.Value.Errors }));
            }

            var loggedUserRole = this.User.FindFirstValue(ClaimTypes.Role);
            request.LoggedUserRole = loggedUserRole;
            var loggedUSerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            request.LoggedUserId = loggedUSerId;



            var response = await this.mediator.Send(request);
            if (response.Error != null)
            {
                return this.ErrorResponse(response.Error);
            }
            return this.Ok(response);
        }
        
        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            var httpCode = GetHttpStatusCode(errorModel.Error);
            return StatusCode((int)httpCode, errorModel);
        }
        private static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            switch (errorType)
            {
                case ErrorType.NotFound:
                    return HttpStatusCode.NotFound;
                case ErrorType.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                case ErrorType.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                case ErrorType.RequestTooLarge:
                    return HttpStatusCode.RequestEntityTooLarge;
                case ErrorType.UnsupportedMediaType:
                    return HttpStatusCode.UnsupportedMediaType;
                case ErrorType.UnsupportedMethod:
                    return HttpStatusCode.MethodNotAllowed;
                case ErrorType.TooManyRequests:
                    return (HttpStatusCode)429;
                default:
                    return HttpStatusCode.BadRequest;
            }
        }
    }
}
