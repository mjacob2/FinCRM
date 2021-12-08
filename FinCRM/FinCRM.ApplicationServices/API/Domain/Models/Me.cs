using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace FinCRM.ApplicationServices.API.Domain.Models
{
    public class Me
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; } // To będzie e-mail
        public string Password { get; set; }

        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public object Salt { get; internal set; }

    }
}
