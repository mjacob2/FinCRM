using MediatR;
using System;
using System.Collections.Generic;

namespace FinCRM.ApplicationServices.API.Domain
{
    public class UpdateClientByIdRequest : IRequest<UpdateClientByIdResponse>
    {
        
        public int Id;
        public string FirstName { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string LastName { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string PhoneNumber { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string Email { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        public string Source { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!

        //public DateTime DateOfCreation; // DateOfCreation powinna zawsze pozostać już taka sama jak przy tworzeniu
        public string Note { get; set; } = ""; // dodane "", żeby nie wyjebało bazy bo przekażemy NULL !!!DZIAŁAA!!!!
        
        //public List<Application>? Applications { get; set; }

    }
}