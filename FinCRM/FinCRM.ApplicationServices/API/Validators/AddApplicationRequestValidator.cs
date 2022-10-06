using FinCRM.ApplicationServices.API.Domain;
using FinCRM.ApplicationServices.API.Domain.Requests;
using FluentValidation;

namespace FinCRM.ApplicationServices.API.Validators
{
    public class AddApplicationRequestValidator : AbstractValidator<AddApplicationRequest>
    {
        public AddApplicationRequestValidator()
        {
            this.RuleFor(x => x.Type).Length(0, 100);
            this.RuleFor(x => x.Goal).Length(0, 100);
            this.RuleFor(x => x.Bank).Length(0, 100);
            this.RuleFor(x => x.LoanAmount).InclusiveBetween(0, 999999999);
            this.RuleFor(x => x.CommissionPercentage).InclusiveBetween(0, 99);
            this.RuleFor(x => x.CommissionAmount).InclusiveBetween(0, 999999999);
            this.RuleFor(x => x.Stage).Length(0, 100);
            this.RuleFor(x => x.Broker).Length(0, 50);
            this.RuleFor(x => x.SellerName).Length(0, 100);
            this.RuleFor(x => x.SellerPhoneNumber).Length(0, 20);
            this.RuleFor(x => x.SellerEmail).Length(0, 100);
            this.RuleFor(x => x.SellerURL).Length(0, 200);
            this.RuleFor(x => x.SellerAddress).Length(0, 200);
            this.RuleFor(x => x.SellerInvestName).Length(0, 200);
            this.RuleFor(x => x.MortgageRegisterNumber).Length(0, 200);
            this.RuleFor(x => x.Address).Length(0, 200);
            this.RuleFor(x => x.Note).Length(0, 1000);

        }
    }
}
