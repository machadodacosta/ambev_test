using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleProductResponse
    {
        public string Product { get; set; } = string.Empty;
        public int Quantity { get; set; } = int.MinValue;
        public decimal UnitPrices { get; set; } = decimal.MinValue;
        public decimal Discounts { get; set; } = decimal.MinValue;
        public decimal TotalAmountForEachItem { get; set; } = decimal.MinValue;
    }
}
