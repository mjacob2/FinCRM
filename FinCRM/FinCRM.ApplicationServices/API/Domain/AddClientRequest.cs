namespace FinCRM.ApplicationServices.API.Domain
{
    using MediatR;
    using System;

    public class AddClientRequest : IRequest<AddClientResponse>
    {
        //Co wymagamy przy Tworzeniu nowego Klienta
        public DateTime? CreatedDate = DateTime.Now; //Czy działa?
        public string? FirstName { get; set; } // dodane = "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string? LastName { get; set; } // dodane = "", żeby nie wyjebało bazy bo przekażemy NULL  !!!DZIAŁAA!!!!
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Source { get; set; } // dodane = "", żeby nie wyjebało bazy bo przekażemy NULL  !!!DZIAŁAA!!!!

        public string? Description { get; set; }
        public string? SneakPeak { get; set; }
        public string? CorrespondenceAddress { get; set; }
        public string? Note { get; set; }

    }
}
