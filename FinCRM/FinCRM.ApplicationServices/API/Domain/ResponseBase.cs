using FinCRM.ApplicationServices.API.Domain.Errors;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class ResponseBase<T> : ErrorResponseBase
    {
        public T? Data { get; set; }
    }
}
