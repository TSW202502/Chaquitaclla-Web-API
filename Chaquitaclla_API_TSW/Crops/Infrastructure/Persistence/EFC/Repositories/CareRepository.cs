using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Configuration;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chaquitaclla_API_TSW.Crops.Infrastructure.Persistence.EFC.Repositories;

public class CareRepository: BaseRepository<Care>, ICareRepository
{
    public CareRepository(AppDbContext context) : base(context)
    {
        
    }
    public async Task<IEnumerable<Care>> GetCaresByCropIdQuery(int cropId)
    {
        var crop = await Context.Set<Crop>()
            .Include(c => c.Cares)
            .FirstOrDefaultAsync(c => c.Id == cropId);

        return crop?.Cares;
    }
}
