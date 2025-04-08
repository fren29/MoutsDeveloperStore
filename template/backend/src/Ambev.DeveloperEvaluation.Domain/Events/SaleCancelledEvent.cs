﻿using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public record SaleCancelledEvent(Guid SaleId) : IDomainEvent;
}