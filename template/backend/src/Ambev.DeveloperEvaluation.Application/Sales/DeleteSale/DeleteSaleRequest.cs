using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}