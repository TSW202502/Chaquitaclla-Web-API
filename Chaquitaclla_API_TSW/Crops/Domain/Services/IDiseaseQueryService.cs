using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;

namespace Chaquitaclla_API_TSW.Crops.Domain.Services;

public interface IDiseaseQueryService
{
    Task<Disease?> Handle(GetDiseaseByIdQuery query);
}