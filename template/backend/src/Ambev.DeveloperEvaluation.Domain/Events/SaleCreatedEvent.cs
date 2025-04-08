using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public record SaleCreatedEvent(Guid SaleId) : IDomainEvent;
}