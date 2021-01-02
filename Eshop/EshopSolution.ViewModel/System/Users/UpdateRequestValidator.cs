using FluentValidation;
using System;

namespace EshopSolution.ViewModel.System.Users
{
    public class UpdateRequestValidator : AbstractValidator<UpdateRequest>
    {
        public UpdateRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Tên không được để trống");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Họ không được để trống");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email không được để trống")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Email không đúng");
            RuleFor(x => x.Dob).NotEmpty().WithMessage("Ngày sinh không được bot trống").LessThan(DateTime.Now.AddYears(-18)).WithMessage("Bạn phải trên 18 tuổi để được đăng kí tài khoản");
        }
    }
}