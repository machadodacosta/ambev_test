namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleProductResult
    {
        public string Product { get; set; } = string.Empty;
        public int Quantity { get; set; } = int.MinValue;
        public decimal UnitPrices { get; set; } = decimal.MinValue;
        public decimal Discounts { get; set; } = decimal.MinValue;
        public decimal TotalAmountForEachItem { get; set; } = decimal.MinValue;
    }
}
