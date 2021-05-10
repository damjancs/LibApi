using FluentValidation;
using LibApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {

        public RegisterUserDtoValidator(LibraryDbContext dbContext)
        {

            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(u => u.Password)
                .MinimumLength(6)
                .Matches(@"[""!@#$%^&*(){}:;<>,.?/+\-_=|'[\]~\\^]").WithMessage("'Password must contain one or more special characters.");

            RuleFor(u => u.ConfirmPassword)
                 .Equal(x => x.Password);

            RuleFor(u => u.Email)
                .Custom((value, context) =>
                {
                    var usedEmail = dbContext.Users.Any(x => x.Email == value);
                    if (usedEmail)
                    {
                        context.AddFailure("Email", "Email you want to use is taken.");
                    }
                });
    
        }
    }
}
