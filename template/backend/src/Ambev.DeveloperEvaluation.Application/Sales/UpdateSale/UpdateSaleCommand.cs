using System;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleCommand : IRequest<UpdateSaleResponse>
    {
        public Guid Id { get; set; }
    }
}