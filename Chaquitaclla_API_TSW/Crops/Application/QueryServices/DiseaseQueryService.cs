using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Crops.Domain.Services;

namespace Chaquitaclla_API_TSW.Crops.Application.QueryServices;

public class DiseaseQueryService(IDiseaseRepository diseaseRepository)
    : IDiseaseQueryService
{
    public async Task<Disease?> Handle(GetDiseaseByIdQuery query)
    {
        return await diseaseRepository.FindByIdAsync(query.Id);
    }    
}
