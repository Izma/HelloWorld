using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace HelloWorld.Models.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
           // RuleFor(x => x.Name).NotEmpty().WithMessage("The field name not should be empty.");
        }
    }
}