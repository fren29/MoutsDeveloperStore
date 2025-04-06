using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        [Fact]
        public void AddItem_WithValidQuantity_ShouldApplyCorrectDiscount()
        {
            var sale = new Sale();

            sale.AddItem(Guid.NewGuid(), "Produto X", 10, 100);

            var item = sale.Items[0];
            Assert.Equal(200, item.Discount);
            Assert.Equal(800, item.TotalAmount);
        }

        [Fact]
        public void AddItem_WithQuantityBelowMinimum_ShouldThrowException()
        {
            var sale = new Sale();
            Assert.Throws<Exception>(() =>
                sale.AddItem(Guid.NewGuid(), "Produto Y", 0, 100));
        }

        [Fact]
        public void Cancel_ShouldSetStatusToCancelled()
        {
            var sale = new Sale();
            sale.Cancel();
            Assert.Equal(SaleStatus.Cancelled, sale.Status);
        }
    }
}