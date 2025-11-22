using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Crops.Domain.Repositories;

public interface IDiseaseRepository : IBaseRepository<Disease>
{
    Task<IEnumerable<Disease>> FindAllAsync();
    
    Task<IEnumerable<Disease>> GetDiseasesByCropId(int cropId);
}
