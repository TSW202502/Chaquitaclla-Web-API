using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;

namespace Chaquitaclla_API_TSW.Crops.Domain.Services;

public interface ISowingQueryService
{
    Task<Sowing?> Handle(GetSowingByIdQuery query);
    Task<IEnumerable<Sowing>> Handle(GetSowingByStatusQuery query);
}