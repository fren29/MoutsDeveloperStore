using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public Guid BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;

        //public SaleStatus Status { get; set; } = SaleStatus.Active;

        //public List<SaleItem> Items { get; set; } = new();

        //public decimal TotalAmount => CalculateTotal();

        //private decimal CalculateTotal()
        //{
        //    decimal total = 0;
        //    foreach (var item in Items)
        //    {
        //        if (!item.IsCancelled)
        //            total += item.TotalAmount;
        //    }
        //    return total;
        //}

        //public void Cancel()
        //{
        //    Status = SaleStatus.Cancelled;
        //}
    }
}