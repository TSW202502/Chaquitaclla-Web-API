using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Crops.Domain.Services;

namespace Chaquitaclla_API_TSW.Crops.Application.QueryServices;

public class SowingQueryService(ISowingRepository sowingRepository)
: ISowingQueryService
{
    public async Task<Sowing?> Handle(GetSowingByIdQuery query)
    {
        return await sowingRepository.FindByIdAsync(query.Id);
    }
    public async Task<IEnumerable<Sowing>> Handle(GetSowingByStatusQuery query)
    {
        return await sowingRepository.FindByStatusAsync(query.Status);
    }

    public async Task<IEnumerable<Product>> Handle(GetProductsBySowingQuery query)
    {
        return await sowingRepository.FindProductsBySowing(query.SowingId);
    }

    public Task<IEnumerable<Sowing>> Handle(GetAllSowingsQuery query)
    {
        return sowingRepository.FindAllAsync();
    }
}