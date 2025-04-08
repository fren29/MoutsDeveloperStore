using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleHandler : IRequestHandler<GetSaleQuery, GetSaleResult>
    {
        private readonly ISaleRepository _saleRepository;

        public GetSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<GetSaleResult> Handle(GetSaleQuery request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(request.Id);
            if (sale == null)
                throw new NotFoundException($"Sale with ID {request.Id} not found");

            return new GetSaleResult
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
