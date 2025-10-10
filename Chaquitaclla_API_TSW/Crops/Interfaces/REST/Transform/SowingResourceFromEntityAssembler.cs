using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;

public static class SowingResourceFromEntityAssembler
{
    public static SowingResource ToResourceFromEntity(Sowing entity)
    {
        return new SowingResource(entity.Id,
            entity.StartDate,
            entity.EndDate,
            entity.AreaLand,
            entity.Status,
            entity.PhenologicalPhase,
            entity.CropId,
            entity.PhenologicalPhase.ToString());
    
}
}

