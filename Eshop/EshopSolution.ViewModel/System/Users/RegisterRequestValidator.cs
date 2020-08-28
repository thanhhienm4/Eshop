using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModel.System.Users
{
    public class RegisterRequestValidator : AbstractValidator <RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required")
                .MinimumLength(6).WithMessage("UserName is at least 6 character");
            RuleFor(x => x.Password).NotEmpty().WithMessage("UserName is required")
                .MinimumLength(8).WithMessage("PassWord is at least 6 character");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Email is incorrected");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone is required");
            RuleFor(x => x.Dob).LessThan(DateTime.Now.AddYears(-18)).WithMessage("You must greater than 18 years old to register");
            RuleFor(x => x).Custom((request, context) => {
                if (request.Password!= request.ConfirmPassword)
                {
                    context.AddFailure("Password is not match");
                }
            });
        }
    }
    
}
