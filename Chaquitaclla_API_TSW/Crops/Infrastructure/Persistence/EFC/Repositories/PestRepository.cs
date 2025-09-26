using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Configuration;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chaquitaclla_API_TSW.Crops.Infrastructure.Persistence.EFC.Repositories;

public class PestRepository : BaseRepository<Pest>, IPestRepository
{
    public PestRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Pest>> FindByCropIdAsync(int cropId)
    {
        return await Context.Set<Pest>()
            .Where(p => p.CropsPests.Any(c => c.CropId == cropId))
            .Include(p => p.CropsPests)
            .ToListAsync();
    }
}