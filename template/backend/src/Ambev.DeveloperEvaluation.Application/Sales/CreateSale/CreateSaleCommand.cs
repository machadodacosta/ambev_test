using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public string Id = Guid.NewGuid().ToString();
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
        public virtual ICollection<CreateSaleProductCommand> Products { get; set; }

        /// <summary>
        /// Gets or sets the  Cancelled/Not Cancelled.
        /// </summary>
        public bool IsCancelled { get; set; } = false;

        public ValidationResultDetail Validate()
        {
            var validator = new CreateSaleCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
