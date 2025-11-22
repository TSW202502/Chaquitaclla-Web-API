using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Configuration;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chaquitaclla_API_TSW.Crops.Infrastructure.Persistence.EFC.Repositories;

public class ControlRepository : BaseRepository<Control>, IControlRepository
{
    public ControlRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Control>> FindBySowingIdAsync(int sowingId)
    {
        return await Context.Set<Control>()
            .Where(c => c.SowingId == sowingId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Control>> FindByIdAndSowingIdAsync(int id, int sowingId)
    {
        return await Context.Set<Control>()
            .Where(c => c.Id == id && c.SowingId == sowingId)
            .ToListAsync();
    }

    public void Delete(Control control)
    {
        Context.Set<Control>().Remove(control);
    }
}
