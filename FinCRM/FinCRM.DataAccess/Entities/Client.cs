using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinCRM.DataAccess.Entities
{
    public class Client : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; } 

        [MaxLength(20)]
        public string? PhoneNumber { get; set; } // Znak zapytania ? oznacza, że dana kolumna w bazie może przyjmować NULLa
        
        [MaxLength(100)]
        public string? Email { get; set; } // Znak zapytania ? oznacza, że dana kolumna w bazie może przyjmować NULLa

        [MaxLength(20)]
        public string? Source { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [MaxLength(20)]
        public string? SneakPeak { get; set; }

        [MaxLength(200)]
        public string? CorrespondenceAddress { get; set; }

        [MaxLength(1000)]
        public string? Note { get; set; }   // Znak zapytania ? oznacza, że dana kolumna w bazie może przyjmować NULLa
        
        // Relacje
        public List<Application>? Applications { get; set; }
        public User? User { get; set; }



    }
}
