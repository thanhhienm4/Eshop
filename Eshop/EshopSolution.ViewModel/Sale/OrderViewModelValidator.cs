using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModels.Sale
{
    public class OrderViewModeltValidator : AbstractValidator<OrderViewModel>
    {
        public OrderViewModeltValidator()
        {
            RuleFor(x => x.ShipName).NotEmpty().WithMessage("ShipName must not be empty");
            RuleFor(x => x.ShipEmail).NotEmpty().WithMessage("ShipEmail must not be empty");
            RuleFor(x => x.ShipEmail).Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("ShipEmail không đúng");
            RuleFor(x => x.ShipAddress).NotEmpty().WithMessage("ShipAddress must not be empty");
            RuleFor(x => x.ShipPhoneNumber).NotEmpty().WithMessage("ShipPhoneNumber must not be empty");
            RuleFor(x => x.ShipPhoneNumber).Matches("[0-9]{10}").WithMessage("ShipPhoneNumber formated incorrectly");
        }
    }
}
