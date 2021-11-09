namespace FinCRM.ApplicationServices.API.Domain
{
    using MediatR;
    public class AddApplicationRequest : IRequest<AddApplicationResponse>
    {

        public string Bank { get; set; }
        public string Type { get; set; }
        public decimal LoanAmount { get; set; }

    }
}
