using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCRM.ApplicationServices.API.Domain.Models
{
    public class Applications
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Bank { get; set; }

        public string Type { get; set; }
        public string Goal { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal CommissionAmount { get; set; }
        public string Stage { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }
        public List<string>? ClientsLastNames { get; set; }
    }
}
