using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Crops.Domain.Services;

namespace Chaquitaclla_API_TSW.Crops.Application.QueryServices;

public class CareQueryService(ICareRepository careRepository)
    : ICareQueryService
{
    public async Task<Care?> Handle(GetCareByIdQuery query)
    {
        return await careRepository.FindByIdAsync(query.Id);
    }
    
    public Task<IEnumerable<Care>> Handle(GetCareByCropIdQuery query)
    {
        return careRepository.GetCaresByCropIdQuery(query.CropId);
    }
}

