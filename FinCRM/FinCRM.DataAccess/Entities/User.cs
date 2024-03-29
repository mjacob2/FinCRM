﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FinCRM.DataAccess.Entities
{
    public class User : EntityBase
    {

        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Username { get; set; }


        [Required]
        [MaxLength(100)]
        public string? Password { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Role { get; set; }


        public string? Salt { get; set; }

        //Relacje
        public List<Application>? Applications { get; set; }
        public List<Client>? Clients { get; set; }


    }
}
