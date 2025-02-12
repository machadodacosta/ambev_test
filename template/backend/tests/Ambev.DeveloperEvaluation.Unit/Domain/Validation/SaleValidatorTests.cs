using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    public class SaleValidatorTests
    {
        private readonly SaleValidator _validator;

        public SaleValidatorTests()
        {
            _validator = new SaleValidator();
        }

        [Fact(DisplayName = "Valid purchases above 5 identical items have a 10% discount.")]
        public void Given_ValidDiscounts_When_Validated_Then_ShouldNotHaveErrors()
        {
            // Arrange
            var sale = new Sale
            {
                Products = [ new SaleProduct { Quantity = 5, UnitPrices = 1, TotalAmountForEachItem = 4.5m, Discounts = 0.5m }]
            };

            // Act
            var result = _validator.TestValidate(sale);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact(DisplayName = "Given invalid purchases above 4 identical items have a 10% discount.")]
        public void Given_Invalid_Sale_DiscountAboveFourItems_ShouldReturnsSuccessResponse()
        {
            // Arrange
            var sale = new Sale
            {
                Products = [new() { Quantity = 5, UnitPrices = 1, TotalAmountForEachItem = 4, Discounts = 1 }]
            };

            // Act
            var result = _validator.TestValidate(sale);

            // Assert
            result.ShouldHaveAnyValidationError().WithErrorMessage("Purchases above 4 identical items have a 10% discount.");
        }

        [Fact(DisplayName = "Given invalid purchases between 10 and 20 identical items have a 20% discount.")]
        public void Given_InvalidDiscountsBetween_10_And_20_When_Validated_Then_ShouldNotHaveErrors()
        {
            // Arrange
            var sale = new Sale
            {
                Products = [new() { Quantity = 15, UnitPrices = 1, TotalAmountForEachItem = 10, Discounts = 5 }]
            };

            // Act
            var result = _validator.TestValidate(sale);

            // Assert
            result.ShouldHaveAnyValidationError().WithErrorMessage("Purchases between 10 and 20 identical items have a 20% discount.");
        }

        [Fact(DisplayName = "Given invalid purchase to sell above 20 identical items.")]
        public void Given_Invalid_Sale_DiscountAboveTwentyItems_ShouldReturnsSuccessResponse()
        {
            // Arrange
            var sale = new Sale
            {
                Products = [
                    new () { Quantity = 2, UnitPrices = 1, TotalAmountForEachItem = 2, Discounts = 0 },
                    new () { Quantity = 21, UnitPrices = 1, TotalAmountForEachItem = 21, Discounts = 18.9m }
                ]
            };

            // Act
            var result = _validator.TestValidate(sale);

            // Assert
            result.ShouldHaveAnyValidationError().WithErrorMessage("It's not possible to sell above 20 identical items.");
        }

        [Fact(DisplayName = "Given invalid purchases below 4 items cannot have a discount.")]
        public void Given_Invalid_Sale_DiscountBelowFourItems_ShouldReturnsSuccessResponse()
        {
            // Arrange
            var sale = new Sale
            {
                Products = [
                    new () { Quantity = 2, UnitPrices = 1, TotalAmountForEachItem = 2, Discounts = 0 },
                    new () { Quantity = 1, UnitPrices = 1, TotalAmountForEachItem = 0.5m, Discounts = 0.5m }
                ]
            };

            // Act
            var result = _validator.TestValidate(sale);

            // Assert
            result.ShouldHaveAnyValidationError().WithErrorMessage("Purchases below 4 items cannot have a discount.");
        }
    }
}
