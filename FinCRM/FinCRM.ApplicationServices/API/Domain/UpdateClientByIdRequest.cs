using MediatR;
using System;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class UpdateClientByIdRequest : RequestBase, IRequest<UpdateClientByIdResponse>
    {

        public int Id;
        public DateTime CreatedDate;
        public string Description { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string SneakPeak { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string CorrespondenceAddress { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string FirstName { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string LastName { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string PhoneNumber { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string Email { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string Source { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string Note { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
    }
}