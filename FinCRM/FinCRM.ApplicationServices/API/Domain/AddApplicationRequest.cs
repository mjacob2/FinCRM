namespace FinCRM.ApplicationServices.API.Domain
{
    using MediatR;
    public class AddApplicationRequest : IRequest<AddApplicationResponse>
    {

        public string Bank { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL  !!!DZIAŁAA!!!!
        public string Type { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL  !!!DZIAŁAA!!!!
        public decimal LoanAmount { get; set; }

    }
}
