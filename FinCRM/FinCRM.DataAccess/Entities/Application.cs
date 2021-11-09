using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.Entities
{
   
   public class Application : EntityBase
    {
    

        // 1 wniosek może obsługiwać wielu klientów
        public List<Client> Clients { get; set; }

        //znak zapytania ? oznacza, że moze przyjmować NULL
        public string? Type { get; set; }

        //znak zapytania ? oznacza, że moze przyjmować NULL
        public string? Bank {  get; set; }

        [Column(TypeName = "decimal(11,2)")]
        public decimal LoanAmount { get; set; }

        [Column(TypeName = "decimal(11,2)")]
        public decimal CommissionAmount { get; set; }

        public DateTime DateOfCreation { get; set; }

        public int Age { get; set; }

        //znak zapytania ? oznacza, że moze przyjmować NULL
        [MaxLength(10000)]
        public string? Note { get; set; }
    }
}
