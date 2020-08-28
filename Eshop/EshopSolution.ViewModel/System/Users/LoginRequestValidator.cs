using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModel.System.Users
{
    public class LoginRequestValidator : AbstractValidator <LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("UserName is required");

        }
    }
}
