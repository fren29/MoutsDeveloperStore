using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public record SaleModifiedEvent(Guid SaleId) : IDomainEvent;
}