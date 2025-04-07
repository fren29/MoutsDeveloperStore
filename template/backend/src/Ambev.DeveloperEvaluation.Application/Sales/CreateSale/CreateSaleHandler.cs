using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;

        public CreateSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = new Sale
            {
                SaleNumber = request.SaleNumber,
                Date = request.Date,
                CustomerId = request.CustomerId,
                CustomerName = request.CustomerName,
                BranchId = request.BranchId,
                BranchName = request.BranchName
            };

            foreach (var item in request.Items)
            {
                sale.AddItem(item.ProductId, item.ProductName, item.Quantity, item.UnitPrice);
            }

            sale.RegisterCreatedEvent();
            await _saleRepository.AddAsync(sale);

            return new CreateSaleResult(sale.Id);
        }
    }
}