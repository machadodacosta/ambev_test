using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    public static class CreateSaleHandlerTestData
    {
        private static readonly Faker<CreateSaleCommand> createSaleHandlerFaker = new Faker<CreateSaleCommand>()
            .RuleFor(s => s.SaleNumber, f => f.Random.Int(1000, 9999))
            .RuleFor(s => s.DateWhenTheSaleWasMade, f => f.Date.Between(DateTime.Now.AddYears(-1), DateTime.Now))
            .RuleFor(s => s.Id, f => Guid.NewGuid().ToString())
            .RuleFor(s => s.Products, f => GenerateProducts(f));

        public static CreateSaleCommand GenerateValidCommand()
        {
            return createSaleHandlerFaker.Generate();
        }

        private static ICollection<CreateSaleProductCommand> GenerateProducts(Faker f)
        {
            var productCount = f.Random.Int(1, 5); // Gera de 1 a 5 produtos por venda
            var products = new List<CreateSaleProductCommand>();

            for (int i = 0; i < productCount; i++)
            {
                var product = new CreateSaleProductCommand
                {
                    Id = f.Random.Guid().ToString(),
                    Quantity = f.Random.Int(1, 10),
                    UnitPrices = f.Random.Decimal(10, 500)
                };
                products.Add(product);
            }

            return products;
        }
    }
}
