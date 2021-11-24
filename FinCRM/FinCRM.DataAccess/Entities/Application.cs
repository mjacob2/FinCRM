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

        //znak zapytania ? oznacza, że moze przyjmować NULL
        [Required]
        [MaxLength(100)]
        public string? Type { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Goal { get; set; }

        //znak zapytania ? oznacza, że moze przyjmować NULL
        [MaxLength(100)]
        public string? Bank {  get; set; }

        [Column(TypeName = "decimal(11,2)")]
        public decimal? LoanAmount { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal? CommissionPercentage { get; set; }

        [Column(TypeName = "decimal(11,2)")]
        public decimal? CommissionAmount { get; set; }

        [MaxLength(100)]
        public string? Stage { get; set; }

        public DateTime? SubmitedDat { get; set; }

        public DateTime? FinishDate { get; set; }

        [MaxLength(50)]
        public string? Broker { get; set; }

        public DateTime? WithdrawalDate { get; set; }

        [MaxLength(100)]
        public string? SellerName { get; set; }

        [MaxLength(20)]
        public string? SellerPhoneNumber { get; set; }

        [MaxLength(100)]
        public string? SellerEmail { get; set; }

        [MaxLength(200)]
        public string? SellerURL { get; set; }

        [MaxLength(200)]
        public string? SellerAddress { get; set; }

        [MaxLength(200)]
        public string? SellerInvestName { get; set; }

        [MaxLength(20)]
        public string? MortgageRegisterNumber { get; set; }

        public DateTime? DeadlineDate { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        //znak zapytania ? oznacza, że moze przyjmować NULL
        [MaxLength(1000)]
        public string? Note { get; set; }

        //Relacje
        public List<Client>? Clients { get; set; }

        public int? UserId { get; set; }



    }
}
