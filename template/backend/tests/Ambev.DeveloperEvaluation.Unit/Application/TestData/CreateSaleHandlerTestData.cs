using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Bogus;
using System;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    public static class CreateSaleHandlerTestData
    {
        private static readonly Faker<CreateSaleItemDto> itemFaker = new Faker<CreateSaleItemDto>()
            .RuleFor(i => i.ProductId, f => Guid.NewGuid())
            .RuleFor(i => i.ProductName, f => f.Commerce.ProductName())
            .RuleFor(i => i.Quantity, f => f.Random.Int(1, 20))
            .RuleFor(i => i.UnitPrice, f => f.Random.Decimal(10, 100));

        private static readonly Faker<CreateSaleRequest> requestFaker = new Faker<CreateSaleRequest>()
            .RuleFor(r => r.SaleNumber, f => f.Random.AlphaNumeric(10))
            .RuleFor(r => r.Date, f => f.Date.Past())
            .RuleFor(r => r.CustomerId, f => Guid.NewGuid())
            .RuleFor(r => r.CustomerName, f => f.Name.FullName())
            .RuleFor(r => r.BranchId, f => Guid.NewGuid())
            .RuleFor(r => r.BranchName, f => f.Company.CompanyName())
            .RuleFor(r => r.Items, f => itemFaker.Generate(f.Random.Int(1, 3)));

        public static CreateSaleRequest GenerateValidRequest() => requestFaker.Generate();
    }
}
