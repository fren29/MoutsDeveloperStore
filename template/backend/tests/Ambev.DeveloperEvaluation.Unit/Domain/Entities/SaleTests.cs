using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        [Fact(DisplayName = "Given valid data When creating sale Then succeeds")]
        public void Create_ValidData_Success()
        {
            var sale = SaleTestData.CreateValidSale();
            sale.Should().NotBeNull();
            sale.TotalAmount.Should().BeGreaterThan(0);
            sale.Items.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "Given 5 items When creating Then apply 10 percent discount")]
        public void Create_With5Items_Apply10PercentDiscount()
        {
            var sale = SaleTestData.CreateWith5ItemsFor10PercentDiscount();
            sale.Items[0].Discount.Should().Be(0.1m * 5 * 100);
        }

        [Fact(DisplayName = "Given 12 items When creating Then apply 20 percent discount")]
        public void Create_With12Items_Apply20PercentDiscount()
        {
            var sale = SaleTestData.CreateWith12ItemsFor20PercentDiscount();
            sale.Items[0].Discount.Should().Be(0.2m * 12 * 100);
        }

        [Fact(DisplayName = "Given more than 20 items When creating Then throws exception")]
        public void Create_WithMoreThan20Items_Throws()
        {
            var act = () => SaleItem.Create(Guid.NewGuid(), "Item 1", 21, 100);
            act.Should().Throw<DomainException>();
        }
    }
}
