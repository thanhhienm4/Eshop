using FluentValidation;

namespace EshopSolution.ViewModels.Catalog.Products
{
    public class ProductUpdateRequestValidator : AbstractValidator<ProductUpdateRequest>
    {
        public ProductUpdateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Không được bỏ trống tên sản phẩm");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Không được bỏ trống");
            RuleFor(x => x.Details).NotEmpty().WithMessage("Không được bỏ trống");
            RuleFor(x => x.Price).NotEqual(0).WithMessage("Không được bỏ tróng giá");
            RuleFor(x => x.OriginalPrice).NotEqual(0).WithMessage("Không được bỏ trống");
        }
    }
}
