using FinCRM.ApplicationServices.API.Domain;
using FluentValidation;


namespace FinCRM.ApplicationServices.API.Validators
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            this.RuleFor(x => x.FirstName).Length(0, 100); 
            this.RuleFor(x => x.LastName).Length(0, 100);
            this.RuleFor(x => x.Username).Length(0, 100);
            this.RuleFor(x => x.Password).Length(0, 100);
            this.RuleFor(x => x.Role).Length(0, 100);

        }
    }
}