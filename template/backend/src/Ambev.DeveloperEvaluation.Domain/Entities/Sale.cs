
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public string SaleNumber { get;  set; } = string.Empty;
        public DateTime SaleDate { get;  set; }
        public string Customer { get;  set; } = string.Empty;
        public string Branch { get;  set; } = string.Empty;
        public bool IsCancelled { get;  set; }

        public List<ItemSale> items = new();

        public decimal TotalAmount => items.Sum(i => i.Total);

        protected Sale() { }

        public Sale(string saleNumber, DateTime saleDate, string customer, string branch)
        {
            Id = Guid.NewGuid();
            SaleNumber = saleNumber;
            SaleDate = saleDate;
            Customer = customer;
            Branch = branch;
        }

        public void AddItem(Guid productId, string productDescription, int quantity, decimal unitPrice)
        {
            var item = new ItemSale(productId, productDescription, quantity, unitPrice);
            items.Add(item);
        }

        public void Cancel() => IsCancelled = true;
    }
}
