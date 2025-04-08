using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateSaleHandlerTests
    {
        private readonly ISaleRepository _repository = Substitute.For<ISaleRepository>();
        private readonly IMapper _mapper = Substitute.For<IMapper>();
        private readonly CreateSaleHandler _handler;

        public CreateSaleHandlerTests()
        {
            _handler = new CreateSaleHandler(_repository);
        }

        [Fact(DisplayName = "Given valid command When creating sale Then returns result")]
        public async Task Handle_ValidCommand_ReturnsResult()
        {
            var command = CreateSaleHandlerTestData.GenerateValidCommand();

            _repository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
                .Returns(callInfo => callInfo.Arg<Sale>());

            var response = await _handler.Handle(command, CancellationToken.None);

            response.Should().NotBeNull();
            response.Id.Should().NotBe(Guid.Empty);
        }
    }
}
