using FluentValidation;

namespace Product.API.Validators
{
    public class ProductValidator : AbstractValidator<BulkRetail.ProductService.Models.ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("Please add a product name");
            RuleFor(p => p.Name).NotEmpty().Length(1, 250).WithMessage("Prouct name must be between 1 and 250 characters. You entered 0 characters.");
            RuleFor(p => p.Brand).NotNull();
            RuleFor(x => x.CostPrice).NotEqual(0).WithMessage("Cost price should not be a zero.");
            RuleFor(x => x.MOQ).NotEqual(0).WithMessage("Minimum order quantity should be one.");
        }
    }
}
