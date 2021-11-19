using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinCRM.DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Username { get; set; } // To będzie e-mail
        [MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string Segment { get; set; }
    }
}
