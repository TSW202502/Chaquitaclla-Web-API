using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Crops.Domain.Repositories;

public interface ICropRepository: IBaseRepository<Crop>
{
    Task UpdateAsync(Crop crop);
}