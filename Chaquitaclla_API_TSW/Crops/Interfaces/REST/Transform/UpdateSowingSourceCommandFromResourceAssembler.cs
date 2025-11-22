using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;

public class UpdateSowingSourceCommandFromResourceAssembler
{
    public static UpdateSowingCommand ToCommandFromResource(UpdateSowingResource resource)
    {
        return new UpdateSowingCommand(resource.AreaLand,resource.CropId);
    }
}
