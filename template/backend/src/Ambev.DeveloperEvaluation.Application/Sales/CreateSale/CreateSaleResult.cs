namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleResult
    {
        public CreateSaleResult(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}