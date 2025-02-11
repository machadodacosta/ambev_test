using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Represents a request to create a new sale in the system.
    /// </summary>
    public class CreateSaleRequest
    {
        /// <summary>
        /// Gets or sets the sale number. Must be unique and contain only valid characters.
        /// </summary>
        public int SaleNumber { get; set; } = int.MinValue;
        /// <summary>
        /// Gets or sets the date when the sale was made .
        /// </summary>
        public DateTime DateWhenTheSaleWasMade { get; set; } = DateTime.MinValue;
        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        public string Customer { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the total sale amount.
        /// </summary>
        public int TotalSaleAmount { get; set; } = int.MinValue;
        /// <summary>
        /// Gets or sets the branch where the sale was made.
        /// </summary>
        public string BranchWhereTheSaleWasMade { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public virtual ICollection<CreateSaleProductRequest> Products { get; set; }

        /// <summary>
        /// Gets or sets the  Cancelled/Not Cancelled.
        /// </summary>
        public bool IsCancelled { get; set; } = false;

    }
}
