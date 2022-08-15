using FinCRM.ApplicationServices.API.Domain;
using FluentValidation;

namespace FinCRM.ApplicationServices.API.Validators
{
    public class AddClientRequestValidator : AbstractValidator<AddClientRequest>
    {
        public AddClientRequestValidator()
        {
            this.RuleFor(x => x.FirstName).Length(0, 100); // Also add .WithMessage("My message");
            this.RuleFor(x => x.LastName).Length(0, 100);
            this.RuleFor(x => x.PhoneNumber).Length(0, 20);
            this.RuleFor(x => x.Email).Length(0, 100);
            this.RuleFor(x => x.Source).Length(0, 20);
            this.RuleFor(x => x.Description).Length(0, 1000);
            this.RuleFor(x => x.SneakPeak).Length(0, 20);
            this.RuleFor(x => x.CorrespondenceAddress).Length(0, 200);
            this.RuleFor(x => x.Note).Length(0, 1000); 
        }
    }
}
