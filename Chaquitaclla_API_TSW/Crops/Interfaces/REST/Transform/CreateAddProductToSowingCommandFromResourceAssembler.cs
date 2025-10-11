using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;

public class CreateAddProductToSowingCommandFromResourceAssembler
{
    public static AddProductToSowingCommand toCommandFromResource(AddProductToSowingResource resource)
    {
        return new AddProductToSowingCommand(
            resource.SowingId,
            resource.ProductId,
            resource.Quantity,
            DateTime.Now
        );
    }
}