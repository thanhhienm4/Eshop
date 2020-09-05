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
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Tên người dùng không được bỏ trống");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Mật khẩu không được bỏ trống")
                .MinimumLength(6).WithMessage("PassWord phải nhiều hơn 6 kí tự");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Tên không được để trống");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Họ không được để trống");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email không được để trống")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Email không đúng");
            RuleFor(x => x.Dob).NotEmpty().WithMessage("Ngày sinh không được bot trống").LessThan(DateTime.Now.AddYears(-18)).WithMessage("Bạn phải trên 18 tuổi để được đăng kí tài khoản");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Mật khẩu không được để trống");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Vui lòng nhập lại mật khẩu");

            RuleFor(x=> x.Password).Equal(x => x.ConfirmPassword).When(customer => !String.IsNullOrWhiteSpace(customer.Password)).WithMessage("Mật khẩu không khớp");
        }
    }
    
}
