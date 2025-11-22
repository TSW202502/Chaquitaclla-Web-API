using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Crops.Domain.Repositories;

public interface ICareRepository :IBaseRepository<Care>
{
    Task<IEnumerable<Care>> GetCaresByCropIdQuery(int cropId);

}
