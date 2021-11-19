using FinCRM.ApplicationServices.API.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCRM.ApplicationServices.API.Validators
{
    public class AddApplicationRequestValidator : AbstractValidator<AddApplicationRequest>
    {
        public AddApplicationRequestValidator()
        {
            this.RuleFor(x => x.Type).Length(0, 100);
            this.RuleFor(x => x.Bank).Length(0, 100);
            //this.RuleFor(x => x.Note).Length(0, 10000);
            this.RuleFor(x => x.LoanAmount).InclusiveBetween(0, 10000000000);
            //this.RuleFor(x => x).InclusiveBetween(0, 10000000000);

        }
    }
}
