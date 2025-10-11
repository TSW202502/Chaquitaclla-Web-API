using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Crops.Domain.Repositories;

public interface IPestRepository : IBaseRepository<Pest>
{
   Task<IEnumerable<Pest>> FindAllAsync();
   
   Task<IEnumerable<Pest>> GetPestByCropIdQuery(int cropId);

   
}