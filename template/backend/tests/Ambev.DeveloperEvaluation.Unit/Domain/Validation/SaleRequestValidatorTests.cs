
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    public  class SaleRequestValidatorTests
    {
        private readonly SaleValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_SaleNumber_Is_Empty()
        {
            var model = new SaleRequest { SaleNumber = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.SaleNumber);
        }

        [Fact]
        public void Should_Have_Error_When_Customer_Is_Empty()
        {
            var model = new SaleRequest { Customer = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Customer);
        }

        [Fact]
        public void Should_Have_Error_When_Branch_Is_Empty()
        {
            var model = new SaleRequest { Branch = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Branch);
        }

        [Fact]
        public void Should_Have_Error_When_Items_Are_Empty()
        {
            var model = new SaleRequest { Items = new List<SaleItemRequest>() };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Items);
        }

        [Fact]
        public void Should_Not_Have_Errors_When_Valid()
        {
            var model = new SaleRequest
            {
                SaleNumber = "12345",
                SaleDate = DateTime.UtcNow,
                Customer = "Customer",
                Branch = "Branch",
                Items = new List<SaleItemRequest>
            {
                new()
                {
                    ProductId = Guid.NewGuid(),
                    ProductDescription = "ProductDescription",
                    Qtd = 5,
                    Price = 10.00m
                }
            }
            };

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
