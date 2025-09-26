using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;

public static class CropResourceFromEntityAssembler
{
    public static CropResource ToResourceFromEntity(Crop entity)
    {

        return new CropResource(entity.Id, entity.Name, entity.Description);
    }
}