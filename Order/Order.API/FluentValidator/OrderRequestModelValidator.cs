using FluentValidation;
using Order.Core.RequestResponseModel;

namespace Order.API.FluentValidator
{
    public class OrderRequestModelValidator : AbstractValidator<OrderRequestModel>
    {
        public OrderRequestModelValidator()
        {
            //RuleFor(x => x.OrderId).NotEmpty();
            //RuleFor(x => x.OrderPriceIncGST).NotEmpty();
            //RuleFor(x => x.CustomerId).NotEmpty();
            //RuleFor(x => x.Discount).LessThan(100);
            //RuleFor(x => x.OrderStatus).NotEmpty();
        }
    }
}
