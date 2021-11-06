using System.ComponentModel.DataAnnotations;
using System;

namespace FinCRM.ApplicationServices.API.Domain.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public string Bank { get; set; }

        public decimal LoanAmount { get; set; }

        public decimal CommissionAmount { get; set; }

        public DateTime DateOfCreation { get; set; }

        public int Age { get; set; }

        public string Note { get; set; }
    }
}
