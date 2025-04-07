using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleValidator()
        {
            RuleFor(x => x.SaleNumber)
                .NotEmpty().WithMessage("Sale number is required.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer is required.");

            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage("Branch is required.");

            RuleFor(x => x.Items)
                .NotNull().WithMessage("Items are required.")
                .Must(i => i.Count > 0).WithMessage("At least one item is required.");

            RuleForEach(x => x.Items).ChildRules(items =>
            {
                items.RuleFor(i => i.ProductId)
                    .NotEmpty().WithMessage("Product is required.");

                items.RuleFor(i => i.Quantity)
                    .GreaterThan(0).WithMessage("Quantity must be greater than zero.")
                    .LessThanOrEqualTo(20).WithMessage("Quantity must not exceed 20.");

                items.RuleFor(i => i.UnitPrice)
                    .GreaterThan(0).WithMessage("Unit price must be greater than zero.");
            });
        }
    }
}