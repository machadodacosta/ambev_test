using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteSale;

public class DeleteSaleProfile : Profile
{
    public DeleteSaleProfile()
    {
        CreateMap<Guid, Application.Users.DeleteSale.DeleteSaleCommand>()
            .ConstructUsing(id => new Application.Users.DeleteSale.DeleteSaleCommand(id));
    }
}
