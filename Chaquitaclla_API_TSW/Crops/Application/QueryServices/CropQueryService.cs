using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Crops.Domain.Services;

namespace Chaquitaclla_API_TSW.Crops.Application.QueryServices;

public class CropQueryService(ICropRepository cropRepository)
    : ICropQueryService
{
    public async Task<Crop?> Handle(GetCropByIdQuery query)
    {
        return await cropRepository.FindByIdAsync(query.Id);
    }    
    
    public async Task<IEnumerable<Crop>> Handle(GetAllCropsQuery query)
    {
        return await cropRepository.FindAllAsync();
    }
}
