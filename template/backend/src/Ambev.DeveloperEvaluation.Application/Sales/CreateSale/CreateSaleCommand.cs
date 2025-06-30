
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public int Qtd { get; set; }
        public decimal Price { get; set; }
    }
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public List<CreateSaleItemDto> Items { get; set; } = new();
    }
        /*
    public ValidationResultDetail Validate()
        {
            var validator = new CreateUserCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
        */
    }
