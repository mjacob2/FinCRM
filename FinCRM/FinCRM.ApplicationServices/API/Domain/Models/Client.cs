using System;
using System.Collections.Generic;

namespace FinCRM.ApplicationServices.API.Domain.Models
{

    // Pobierając dane z bazy nie dostaniemy wszystkiego, co daje GET, tylko te rzeczy, co będą tutaj opisane
    public class Client
    {

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Source { get; set; }
        public string? Description { get; set; }
        public string? SneakPeak { get; set; }
        public string? CorrespondenceAddress { get; set; }
        public string? Note { get; set; }
        public List<Application>? Applications { get; set; }
        public int? UserId { get; set; }
    }
}