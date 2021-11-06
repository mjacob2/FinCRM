using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
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

        public string Type { get; set; }

        public string Bank {  get; set; }

        [Column(TypeName = "decimal(15,6)")]
        public decimal LoanAmount { get; set; }

        [Column(TypeName = "decimal(15,6)")]
        public decimal CommissionAmount { get; set; }

        public DateTime DateOfCreation { get; set; }

        public int Age { get; set; }

        [MaxLength(10000)]
        public string Note { get; set; }
    }
}
