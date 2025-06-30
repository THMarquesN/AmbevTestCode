using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public  class ItemSale
    {
        public Guid Id { get;  set; }
        public Guid ProductId { get;  set; }
        public string Description { get;  set; }
        public int Qtd { get;  set; }
        public decimal Price { get;  set; }
        public decimal Discount { get;  set; }
        public decimal Total => (Qtd * Price) - Discount;

        public ItemSale(Guid productId, string description, int quantity, decimal price)
        {
            if (quantity > 20)
                throw new InvalidOperationException("Cannot sell more than 20 items.");

            ProductId = productId;
            Description = description;
            Qtd = quantity;
            Price = price;

            Discount = CalculateDiscount(quantity, price);
        }

        private decimal CalculateDiscount(int quantity, decimal unitPrice)
        {
            if (quantity >= 10)
                return 0.20m * quantity * unitPrice;
            if (quantity >= 4)
                return 0.10m * quantity * unitPrice;
            return 0;
        }
    }
}
