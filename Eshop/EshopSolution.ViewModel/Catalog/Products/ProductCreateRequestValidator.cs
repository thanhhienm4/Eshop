using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModel.Catalog.Products
{
    public class ProductCreateRequestValidator : AbstractValidator<ProductCreateRequest>
    {
        public ProductCreateRequestValidator()
        {
            RuleFor(x => x.OriginalPrice).NotEmpty().WithMessage("không được bỏ trống");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Không được bỏ trống tên sản phẩm");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Không được bỏ trống tên mặt hàng");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Không được bỏ trống");


        }
    }
}
