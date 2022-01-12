using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FinCRM.ApplicationServices.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Username { get; set; } // To będzie e-mail

        public string? Role { get; set; }

        public DateTime CreatedDate { get; set; }
        public List<Application>? Applications { get; set; }
        public List<Clients>? Clients { get; set; }


        [JsonIgnore] // The [JsonIgnore] attribute prevents the PasswordHash property from being serialized and returned in api responses.
        public string? Password { get; set; }

        [JsonIgnore] // The [JsonIgnore] attribute prevents the PasswordHash property from being serialized and returned in api responses.
        public string? Salt { get; internal set; }
    }
}
