namespace FinCRM.ApplicationServices.API.Domain
{
    using MediatR;
    public class AddClientRequest : IRequest<AddClientResponse>
    {
        //Co wymagamy przy Tworzeniu nowego Klienta
        public string FirstName { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string LastName { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL  !!!DZIAŁAA!!!!
        public string Source { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL  !!!DZIAŁAA!!!!

    }
}
