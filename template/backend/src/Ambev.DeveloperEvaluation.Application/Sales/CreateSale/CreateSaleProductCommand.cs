﻿namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleProductCommand
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Gets or sets product name.
        /// </summary>
        public string Product { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the quantities.
        /// </summary>
        public int Quantity { get; set; } = int.MinValue;
        /// <summary>
        /// Gets or sets the unit prices.
        /// </summary>
        public decimal UnitPrices { get; set; } = decimal.MinValue;
        /// <summary>
        /// Gets or sets the unit discounts.
        /// </summary>
        public decimal Discounts { get; set; } = decimal.MinValue;
        /// <summary>
        /// Gets or sets the Total amount for each item.
        /// </summary>
        public decimal TotalAmountForEachItem { get; set; } = decimal.MinValue;
    }
}
