namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleResponse
    {
        public CreateSaleResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}