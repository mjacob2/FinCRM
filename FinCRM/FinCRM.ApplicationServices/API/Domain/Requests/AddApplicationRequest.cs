using System;
using FinCRM.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace FinCRM.ApplicationServices.API.Domain.Requests
{
    public class AddApplicationRequest : RequestBase, IRequest<AddApplicationResponse>
    {
        public DateTime CreatedDate { get; set; }
        public string Type { get; set; } = "";
        public string Goal { get; set; } = "";
        public string Bank { get; set; } = "";
        public decimal LoanAmount { get; set; }
        public decimal CommissionPercentage { get; set; }
        public decimal CommissionAmount { get; set; }
        public string Stage { get; set; } = "";
        public DateTime SubmitedDat { get; set; }
        public DateTime FinishDate { get; set; }
        public string Broker { get; set; } = "";
        public DateTime WithdrawalDate { get; set; }
        public string SellerName { get; set; } = "";
        public string SellerPhoneNumber { get; set; } = "";
        public string SellerEmail { get; set; } = "";
        public string SellerURL { get; set; } = "";
        public string SellerAddress { get; set; } = "";
        public string SellerInvestName { get; set; } = "";
        public string MortgageRegisterNumber { get; set; } = "";
        public DateTime DeadlineDate { get; set; }
        public string Address { get; set; } = "";
        public string Note { get; set; } = "";

    }
}
