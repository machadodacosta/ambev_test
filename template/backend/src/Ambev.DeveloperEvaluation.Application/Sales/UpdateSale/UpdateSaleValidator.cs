﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
    {
        private int maxItems = 20;

        public UpdateSaleCommandValidator()
        {
            RuleForEach(f => f.Products).Must(product => IsValidDiscountAboveFourIdenticalItems(product)).WithMessage("Purchases above 4 identical items have a 10% discount.");
            RuleForEach(f => f.Products).Must(product => IsValidDiscountBetweenTenAndtwentyItems(product)).WithMessage("Purchases between 10 and 20 identical items have a 20% discount.");
            RuleForEach(f => f.Products).Must(product => IsNotPossibleToSellAbove20IdenticalItems(product)).WithMessage("It's not possible to sell above 20 identical items.");
            RuleFor(f => f.Products).Must(products => IsNotPossibleToHaveDiscountForPurchaseBelowFourItems(products.ToList())).WithMessage("Purchases below 4 items cannot have a discount.");
        }
        private bool IsValidDiscountAboveFourIdenticalItems(UpdateSaleProductCommand product)
        {
            if (product.Quantity > 4 && product.Quantity < 10)
            {
                return product.Discounts == (product.UnitPrices * product.Quantity) * 0.10m;
            }
            return true;
        }
        private bool IsValidDiscountBetweenTenAndtwentyItems(UpdateSaleProductCommand product)
        {
            if (product.Quantity >= 10 && product.Quantity <= 20)
            {
                return product.Discounts == (product.UnitPrices * product.Quantity) * 0.20m;
            }
            return true;
        }

        private bool IsNotPossibleToSellAbove20IdenticalItems(UpdateSaleProductCommand product)
        {
            return product.Quantity <= 20;
        }

        private bool IsNotPossibleToHaveDiscountForPurchaseBelowFourItems(IList<UpdateSaleProductCommand> products)
        {
            return products.Sum(p => p.Quantity) >= 4 || products.Sum(p => p.Discounts) <= 0;
        }
    }
}
