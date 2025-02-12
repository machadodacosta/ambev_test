using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="CreateSaleHandler"/> class.
/// </summary>
public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly CreateSaleHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreatesaleHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new CreateSaleHandler(_saleRepository, _mapper);
    }

    /// <summary>
    /// Tests that a valid sale creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid purchases above 4 identical items have a 10% discount.")]
    public async Task Handle_Valid_Sale_Four_Items_ShouldReturnsSuccessResponse()
    {
        // Given
        var command = new CreateSaleCommand();
        var sale = new Sale { Id = Guid.Parse(command.Id), Products = [new () { Quantity = 5, UnitPrices = 1, TotalAmountForEachItem = 4.5m, Discounts = 0.5m }] };
        var result = new CreateSaleResult { Id = command.Id };

        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);

        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);

        // When
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleResult.Should().NotBeNull();
        createSaleResult.Id.Should().Be(sale.Id.ToString());
        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that a valid sale creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid  purchases between 10 and 20 identical items have a 20% discount.")]
    public async Task Handle_Valid_Sale_Fifteen_Items_ShouldReturnsSuccessResponse()
    {
        // Given
        var command = new CreateSaleCommand();
        var sale = new Sale { Id = Guid.Parse(command.Id), Products = [new() { Id = Guid.NewGuid(), Product = "Teste", Quantity = 15, UnitPrices = 1, TotalAmountForEachItem = 12, Discounts = 3 }] };
        var result = new CreateSaleResult { Id = command.Id };

        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);

        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);

        // When
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleResult.Should().NotBeNull();
        createSaleResult.Id.Should().Be(sale.Id.ToString());
        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that a valid sale creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid purchase to sell above 20 identical items.")]
    public async Task Handle_Valid_Sale_Nineteen_Items_ShouldReturnsSuccessResponse()
    {
        // Given
        var command = new CreateSaleCommand();
        var sale = new Sale { Id = Guid.Parse(command.Id), Products = [new() { Quantity = 19, UnitPrices = 1, TotalAmountForEachItem = 15.2m, Discounts = 3.8m }] };
        var result = new CreateSaleResult { Id = command.Id };

        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);

        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);

        // When
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleResult.Should().NotBeNull();
        createSaleResult.Id.Should().Be(sale.Id.ToString());
        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that a valid sale creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid purchases below 4 items cannot have a discount.")]
    public async Task Handle_Valid_Sale_Three_Items_ShouldReturnsSuccessResponse()
    {
        // Given
        var command = new CreateSaleCommand();
        var sale = new Sale 
        { 
            Id = Guid.Parse(command.Id),
            Products = [
                new () { Quantity = 2, UnitPrices = 1, TotalAmountForEachItem = 2, Discounts = 0 },
                new () { Quantity = 1, UnitPrices = 1, TotalAmountForEachItem = 1, Discounts = 0 }
            ]
        };
        var result = new CreateSaleResult { Id = command.Id };

        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);

        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);

        // When
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleResult.Should().NotBeNull();
        createSaleResult.Id.Should().Be(sale.Id.ToString());
        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }
}
