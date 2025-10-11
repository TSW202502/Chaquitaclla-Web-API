using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
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

    public async Task<IEnumerable<Product>> FindProductsBySowing(int sowingId)
    {
        var productsBySowing = await Context.Set<ProductsBySowing>()
            .Include(pbs => pbs.Product)
            .Where(pbs => pbs.SowingId == sowingId)
            .ToListAsync();

        return productsBySowing.Select(pbs => pbs.Product);

    }
    public async Task<IEnumerable<Sowing>> FindAllAsync()
    {
        return await Context.Set<Sowing>().ToListAsync();
    }
}