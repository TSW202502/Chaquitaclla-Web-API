using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Configuration;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chaquitaclla_API_TSW.Crops.Infrastructure.Persistence.EFC.Repositories;

public class DiseaseRepository  : BaseRepository<Disease>, IDiseaseRepository
{
    public DiseaseRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Disease>> FindByCropIdAsync(int cropId)
    {
        return await Context.Set<Disease>()
            .Where(d => d.CropsDiseases.Any(c => c.CropId == cropId))
            .Include(d => d.CropsDiseases)
            .ToListAsync();
    }
}