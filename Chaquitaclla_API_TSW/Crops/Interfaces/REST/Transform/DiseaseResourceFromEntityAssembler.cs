using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;

public static class DiseaseResourceFromEntityAssembler
{
    public static DiseaseResource ToResourceFromEntity(Disease entity)
    {
        return new DiseaseResource(entity.Id,
            entity.Name,
            entity.Description,
            entity.Solution);
    }
}