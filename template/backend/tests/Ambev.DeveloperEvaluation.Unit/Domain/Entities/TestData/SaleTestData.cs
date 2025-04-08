using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class SaleTestData
    {
        private static readonly Faker<SaleItem> itemFaker = new Faker<SaleItem>()
            .CustomInstantiator(f => SaleItem.Create(
                Guid.NewGuid(),
                f.Commerce.ProductName(),
                f.Random.Int(1, 20),
                f.Random.Decimal(10, 100)));

        public static Sale CreateValidSale()
        {
            return Sale.Create(
                saleNumber: Guid.NewGuid().ToString().Substring(0, 8),
                date: DateTime.UtcNow,
                customerId: Guid.NewGuid(),
                customerName: "Customer Test",
                branchId: Guid.NewGuid(),
                branchName: "Branch Test",
                items: itemFaker.Generate(3)
            );
        }

        public static Sale CreateWith5ItemsFor10PercentDiscount()
        {
            var items = new[]
            {
                SaleItem.Create(Guid.NewGuid(), "Item 1", 5, 100)
            };

            return Sale.Create("SALE01", DateTime.Now, Guid.NewGuid(), "Test", Guid.NewGuid(), "Test", items);
        }

        public static Sale CreateWith12ItemsFor20PercentDiscount()
        {
            var items = new[]
            {
                SaleItem.Create(Guid.NewGuid(), "Item 1", 12, 100)
            };

            return Sale.Create("SALE02", DateTime.Now, Guid.NewGuid(), "Test", Guid.NewGuid(), "Test", items);
        }
    }
}