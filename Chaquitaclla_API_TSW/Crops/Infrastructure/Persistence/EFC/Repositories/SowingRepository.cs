using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Configuration;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chaquitaclla_API_TSW.Crops.Infrastructure.Persistence.EFC.Repositories;

public class SowingRepository : BaseRepository<Sowing>, ISowingRepository
{
    public SowingRepository(AppDbContext context):base(context)
    {
    } 
    public async Task<IEnumerable<Sowing>> FindByStatusAsync(bool status)
    {
        return await Context.Set<Sowing>().Where(f => f.Status == status)
            .ToListAsync();
    }

    public async Task UpdateAsync(Sowing sowing)
    {
    Context.Set<Sowing>().Update(sowing);
    await Context.SaveChangesAsync();
    }
}