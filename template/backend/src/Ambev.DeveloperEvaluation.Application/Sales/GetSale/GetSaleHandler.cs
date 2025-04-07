using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleHandler : IRequestHandler<GetSaleRequest, GetSaleResponse>
    {
        private readonly ISaleRepository _saleRepository;

        public GetSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<GetSaleResponse> Handle(GetSaleRequest request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(request.Id);
            return sale == null
                ? throw new NotFoundException($"Sale with ID {request.Id} not found")
                : new GetSaleResponse
            {
                Id = sale.Id,
                SaleNumber = sale.SaleNumber,
                Date = sale.Date,
                CustomerName = sale.CustomerName,
                BranchName = sale.BranchName,
                Items = sale.Items.Select(item => new GetSaleItemResponse
                {
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Discount = item.Discount,
                    TotalAmount = item.TotalAmount
                }).ToList()
            };
        }
    }
}
