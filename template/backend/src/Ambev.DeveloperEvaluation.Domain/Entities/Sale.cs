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
            var item = SaleItem.Create(productId, productName, quantity, unitPrice);
            Items.Add(item);
        }

        public static Sale Create(
            string saleNumber,
            DateTime date,
            Guid customerId,
            string customerName,
            Guid branchId,
            string branchName,
            IEnumerable<SaleItem> items)
        {
            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                SaleNumber = saleNumber,
                Date = date,
                CustomerId = customerId,
                CustomerName = customerName,
                BranchId = branchId,
                BranchName = branchName,
                Items = items.ToList()
            };

            sale.RegisterCreatedEvent();
            return sale;
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