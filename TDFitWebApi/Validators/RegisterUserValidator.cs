using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDFitWebApi.Entities;
using TDFitWebApi.Models;

namespace TDFitWebApi.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(TDFitContext tDFitContext)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).MinimumLength(6);
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword);
            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var userAlreadyExists = tDFitContext.Users.Any(user => user.Email == value);
                if (userAlreadyExists)
                {
                    context.AddFailure("Email", "That email address is taken");
                }
            });
        }


    }
}
