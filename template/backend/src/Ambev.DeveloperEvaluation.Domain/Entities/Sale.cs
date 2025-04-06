using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public Guid BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;

        public SaleStatus Status { get; set; } = SaleStatus.Active;

        public List<SaleItem> Items { get; set; } = new();

        public List<IDomainEvent> DomainEvents { get; private set; } = new();

        public decimal TotalAmount => CalculateTotal();

        public void AddItem(Guid productId, string productName, int quantity, decimal unitPrice)
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

            var item = new SaleItem
            {
                ProductId = productId,
                ProductName = productName,
                Quantity = quantity,
                UnitPrice = unitPrice,
                Discount = discount
            };

            Items.Add(item);
        }

        public void RegisterCreatedEvent()
        {
            DomainEvents.Add(new SaleCreatedEvent(Id));
        }

        public void RegisterModifiedEvent()
        {
            DomainEvents.Add(new SaleModifiedEvent(Id));
        }

        public void Cancel()
        {
            Status = SaleStatus.Cancelled;
            DomainEvents.Add(new SaleCancelledEvent(Id));
        }

        private decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                if (!item.IsCancelled)
                    total += item.TotalAmount;
            }
            return total;
        }
    }
}
