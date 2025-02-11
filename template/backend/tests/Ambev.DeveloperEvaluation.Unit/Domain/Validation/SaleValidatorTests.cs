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
                Products = [ new SaleProduct { Quantity = 5, UnitPrices = 1, TotalAmountForEachItem = 3.6m, Discounts = 0.4m }]
            };

            // Act
            var result = _validator.TestValidate(sale);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

    }
}
