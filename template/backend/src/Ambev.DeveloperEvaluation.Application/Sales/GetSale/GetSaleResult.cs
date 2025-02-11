namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleResult
    {
        public Guid Id { get; set; }

        public int SaleNumber { get; set; } = int.MinValue;
        public DateTime DateWhenTheSaleWasMade { get; set; } = DateTime.MinValue;
        public string Customer { get; set; } = string.Empty;
        public int TotalSaleAmount { get; set; } = int.MinValue;
        public string BranchWhereTheSaleWasMade { get; set; } = string.Empty;

        public bool IsCancelled { get; set; } = false;
        public virtual ICollection<GetSaleProductResult> Products { get; set; }
    }
}
