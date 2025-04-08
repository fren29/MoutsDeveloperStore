using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Bogus;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    public static class CreateSaleHandlerTestData
    {
        private static readonly Faker<CreateSaleItemDto> itemFaker = new Faker<CreateSaleItemDto>()
            .RuleFor(i => i.ProductId, f => Guid.NewGuid())
            .RuleFor(i => i.ProductName, f => f.Commerce.ProductName())
            .RuleFor(i => i.Quantity, f => f.Random.Int(1, 10))
            .RuleFor(i => i.UnitPrice, f => f.Random.Decimal(10, 100));

        public static CreateSaleCommand GenerateValidCommand()
        {
            return new CreateSaleCommand
            {
                SaleNumber = Guid.NewGuid().ToString().Substring(0, 6),
                CustomerId = Guid.NewGuid(),
                CustomerName = "Test Customer",
                BranchId = Guid.NewGuid(),
                BranchName = "Test Branch",
                Date = DateTime.UtcNow,
                Items = itemFaker.Generate(3)
            };
        }
    }
}