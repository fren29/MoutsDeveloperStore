using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleRequest, UpdateSaleResponse>
    {
        private readonly ISaleRepository _saleRepository;

        public UpdateSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<UpdateSaleResponse> Handle(UpdateSaleRequest request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(request.Id);
            if (sale == null)
                throw new NotFoundException($"Sale with ID {request.Id} not found");

            sale.RegisterModifiedEvent();
            return new UpdateSaleResponse(sale.Id);
        }
    }
}
