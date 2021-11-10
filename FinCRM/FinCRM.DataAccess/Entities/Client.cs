using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinCRM.DataAccess.Entities
{
    public class Client : EntityBase
    {
        
        // 1 klient może mieć całą listę wniosków
        public List<Application> Applications { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; } 

        [MaxLength(20)]
        public string? PhoneNumber { get; set; } // Znak zapytania ? oznacza, że dana kolumna w bazie może przyjmować NULLa
        
        [MaxLength(100)]
        public string? Email { get; set; } // Znak zapytania ? oznacza, że dana kolumna w bazie może przyjmować NULLa

        [MaxLength(20)]
        public string Source { get; set; }   
        
        public int Age { get; set; }

        public DateTime DateOfCreation { get; set; }

        [MaxLength(10000)]
        public string? Note { get; set; }   // Znak zapytania ? oznacza, że dana kolumna w bazie może przyjmować NULLa




    }
}
