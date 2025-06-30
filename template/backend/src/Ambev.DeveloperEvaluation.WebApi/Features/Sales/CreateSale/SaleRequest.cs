using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class SaleRequest
    {
        public Guid RequestId { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public List<SaleItemRequest> Items { get; set; } = new();
    }

    public class SaleItemRequest
    {
        public Guid ProductId { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public int Qtd { get; set; }
        public decimal Price { get; set; }
    }
}
