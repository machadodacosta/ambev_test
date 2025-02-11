using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.DeleteSale;

public record DeleteSaleCommand : IRequest<DeleteSaleResponse>
{
    public Guid Id { get; }

    public DeleteSaleCommand(Guid id)
    {
        Id = id;
    }
}
