using System;

namespace FinCRM.ApplicationServices.API.Domain.Models
{

    // Pobierając dane z bazy nie dostaniemy wszystkiego, co daje GET, tylko te rzeczy, co będą tutaj opisane
   public class Clients
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Source { get; set; }
        public string SneakPeak { get; set; }
        public int UserId { get; set; }
    }
}

