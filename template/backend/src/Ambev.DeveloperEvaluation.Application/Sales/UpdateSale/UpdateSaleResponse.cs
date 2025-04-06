using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleResponse
    {
        public UpdateSaleResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
