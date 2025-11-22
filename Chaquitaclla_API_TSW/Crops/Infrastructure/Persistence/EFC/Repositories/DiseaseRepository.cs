using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
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
    
    public async Task<IEnumerable<Disease>> FindAllAsync()
    {
        return await Context.Set<Disease>().ToListAsync();
    }
    
    public async Task<IEnumerable<Disease>> GetDiseasesByCropId(int cropId)
    {
        var crop = await Context.Set<Crop>()
            .Include(c => c.Diseases)
            .FirstOrDefaultAsync(c => c.Id == cropId);

        return crop?.Diseases;
    }
}
