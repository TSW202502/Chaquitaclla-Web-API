using Chaquitaclla_API_TSW.Profiles.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Profiles.Domain.Model.ValueObjects;
using Chaquitaclla_API_TSW.Profiles.Domain.Repositories;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Configuration;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chaquitaclla_API_TSW.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<Profile>(context), IProfileRepository
{
    public Task<Profile?> FindProfileByEmailAsync(EmailAddress email)
    {
        return Context.Set<Profile>().Where(p => p.Email == email).FirstOrDefaultAsync();
    }

    public Task<Profile?> GetProfileByIdAsync(int profileId)
    {
        return Context.Set<Profile>().FirstOrDefaultAsync(p => p.Id == profileId);
    }
    public async Task UpdateProfile(Profile profile)
    {
        Context.Set<Profile>().Update(profile);
        await Context.SaveChangesAsync();
    }
}
