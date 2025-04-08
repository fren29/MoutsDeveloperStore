using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleResult
    {
        public UpdateSaleResult(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
