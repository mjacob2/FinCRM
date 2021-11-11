using MediatR;
using System;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class UpdateClientByIdRequest : IRequest<UpdateClientByIdResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string LastName { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string PhoneNumber { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string Email { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string Source { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public int Age { get; set; }
        public string Note { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
    }
}