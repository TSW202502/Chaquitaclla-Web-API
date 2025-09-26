using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Crops.Domain.Repositories;

public interface ISowingRepository : IBaseRepository<Sowing>
{
    Task<IEnumerable<Sowing>> FindByStatusAsync(bool status);
    Task UpdateAsync(Sowing sowing);
}