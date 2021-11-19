using FinCRM.ApplicationServices.API.Domain.Errors;
using FinCRM.ApplicationServices.API.ErrorHandling;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FinCRM.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        // Wstrzykujemy Mediatora
        protected readonly IMediator mediator;
        protected ApiControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
        }
        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            // Najpierw sprawdzamy, czy nasz request jest !NIEprawidłowy
            if (!this.ModelState.IsValid)
            {
                // Jeśli jest nieprawidłowy, to
                return this.BadRequest(
                    // Z naszego ModelState
                    this.ModelState
                        // Wybieraj wszystkie te wartości, które mają jakiś błąd
                        .Where(x => x.Value.Errors.Any())// Faktyczne błędy są w tym miejscu: Value.Erro
                                                         // I z tych wartości wyciągam property a Errory przepisuję do wartości errors
                        .Select(x => new { property = x.Key, errors = x.Value.Errors }));
            }
            // To jest ta metoda, która siedziała do tej pory w każdym z Verbów w Kontrolerach
            var response = await this.mediator.Send(request);
            // Teraz sprawdzamy, czy jest jakiś błąd podczas próby dodania do bazy
            if (response.Error != null)
            {
                return this.ErrorResponse(response.Error);
            }
            //Jeśli nie ma błędu, to wysyłamy OK kod 200
            return this.Ok(response);
        }
        //
        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            //Na podstawie Modelu będziemy wyciągać Http status, żeby na podstawie błędu jaki przyszedł, przygotować odpowiedni kod odpowiedzi w naszym alercie o błędzie
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
                    return HttpStatusCode.BadRequest;//kod: 400
            }
        }
    }
}
