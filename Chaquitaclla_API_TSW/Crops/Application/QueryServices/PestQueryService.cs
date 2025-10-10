using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Crops.Domain.Services;

namespace Chaquitaclla_API_TSW.Crops.Application.QueryServices;

public class PestQueryService(IPestRepository pestRepository)
    : IPestQueryService
{
    public async Task<Pest?> Handle(GetPestByIdQuery query)
    {
        return await pestRepository.FindByIdAsync(query.Id);
    }
    
    public Task<IEnumerable<Pest>> Handle(GetAllPestsQuery query)
    {
        return pestRepository.FindAllAsync();
    }
    public Task<IEnumerable<Pest>> Handle(GetPestByCropIdQuery query)
    {
        return pestRepository.GetPestByCropIdQuery(query.CropId);
    }
}
