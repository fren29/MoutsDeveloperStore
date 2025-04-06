using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}