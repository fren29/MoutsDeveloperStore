using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public record SaleItemCancelledEvent(Guid SaleId, Guid ItemId) : IDomainEvent;
}