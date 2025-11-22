using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Crops.Domain.Repositories
{
    public interface IControlRepository : IBaseRepository<Control>
    {
        Task<IEnumerable<Control>> FindBySowingIdAsync(int sowingId);
        
        Task<IEnumerable<Control>> FindByIdAndSowingIdAsync(int id, int sowingId);
    }
}
