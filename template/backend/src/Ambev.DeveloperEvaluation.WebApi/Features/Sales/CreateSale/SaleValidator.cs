using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class SaleValidator : AbstractValidator<SaleRequest>
    {
        public SaleValidator()
        {
            RuleFor(x => x.SaleNumber)
            .NotEmpty().WithMessage("SaleNumber is required.");

            RuleFor(x => x.Customer)
                .NotEmpty().WithMessage("Customer is required.");

            RuleFor(x => x.Branch)
                .NotEmpty().WithMessage("Branch is required.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("At least one item is required.");

            RuleForEach(x => x.Items).SetValidator(new SaleItemValidator());
        }
    }

    public class SaleItemValidator : AbstractValidator<SaleItemRequest>
    {
        public SaleItemValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId is required.");

            RuleFor(x => x.Qtd)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
                .LessThanOrEqualTo(20).WithMessage("Quantity must not exceed 20.");
        }
    }
}
