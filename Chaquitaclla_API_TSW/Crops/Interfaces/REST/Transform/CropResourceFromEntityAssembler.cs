using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;

public static class CropResourceFromEntityAssembler
{
    public static CropResource ToResourceFromEntity(Crop entity)
    {
        var diseaseIds = entity.Diseases?.Select(d => d.Id).ToList() ?? new List<int>();
        var pestIds = entity.Pests?.Select(p => p.Id).ToList() ?? new List<int>();
        var careIds = entity.Cares?.Select(c => c.Id).ToList() ?? new List<int>();

        return new CropResource(entity.Id, entity.Name, entity.Description, entity.ImageUrl, diseaseIds, pestIds,
            careIds);
    }
}