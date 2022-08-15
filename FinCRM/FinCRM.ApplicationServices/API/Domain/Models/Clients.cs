using System;

namespace FinCRM.ApplicationServices.API.Domain.Models
{

   public class Clients
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Source { get; set; }
        public string Stage { get; set; }
        public string SneakPeak { get; set; }
        public User User { get; set; }
    }
}

