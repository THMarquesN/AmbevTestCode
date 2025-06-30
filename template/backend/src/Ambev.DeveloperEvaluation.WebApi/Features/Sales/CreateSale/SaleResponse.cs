using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class SaleResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<Sale> Sales { get; set; } = new List<Sale>();
    }
}
