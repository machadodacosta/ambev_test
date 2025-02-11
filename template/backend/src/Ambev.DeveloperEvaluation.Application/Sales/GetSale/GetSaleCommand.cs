using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleCommand : IRequest<GetSaleResult>
    {
        public Guid Id { get; }

        public GetSaleCommand(Guid id)
        {
            Id = id;
        }
    }
}
