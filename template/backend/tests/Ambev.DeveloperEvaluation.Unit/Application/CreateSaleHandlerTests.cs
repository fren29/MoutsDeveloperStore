using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.CreateSale
{
    public class CreateSaleHandlerTests
    {
        private readonly ISaleRepository _repository;
        private readonly CreateSaleHandler _handler;

        public CreateSaleHandlerTests()
        {
            _repository = Substitute.For<ISaleRepository>();
            _handler = new CreateSaleHandler(_repository);
        }

        [Fact(DisplayName = "Given valid sale request When handled Then returns response with Id")]
        public async Task Handle_ValidRequest_ReturnsSaleId()
        {
            // Arrange
            var request = CreateSaleHandlerTestData.GenerateValidRequest();
            await _repository.AddAsync(Arg.Any<Sale>()); // setup implícito do NSubstitute

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBe(Guid.Empty);
            await _repository.Received(1).AddAsync(Arg.Any<Sale>());
        }
    }
}
