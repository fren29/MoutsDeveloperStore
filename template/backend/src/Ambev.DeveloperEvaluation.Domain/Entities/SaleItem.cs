using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Exceptions;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

        public decimal TotalAmount => Quantity * UnitPrice - Discount;

        public bool IsCancelled { get; set; } = false;

        public static SaleItem Create(Guid productId, string productName, int quantity, decimal unitPrice)
        {
            if (quantity < 1)
                throw new DomainException("Quantity must be at least 1.");

            if (quantity > 20)
                throw new DomainException("Cannot sell more than 20 items of the same product.");

            decimal discount = 0;
            if (quantity >= 10)
                discount = 0.20m * quantity * unitPrice;
            else if (quantity >= 4)
                discount = 0.10m * quantity * unitPrice;

            return new SaleItem
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                ProductName = productName,
                Quantity = quantity,
                UnitPrice = unitPrice,
                Discount = discount
            };
        }
    }
}
