using Chaquitaclla_API_TSW.Profiles.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Profiles.Domain.Model.Querys;
using Chaquitaclla_API_TSW.Profiles.Domain.Repositories;
using Chaquitaclla_API_TSW.Profiles.Domain.Services;

namespace Chaquitaclla_API_TSW.Profiles.Application.Internal.QueryServices;

public class ProfileQueryService(IProfileRepository profileRepository) : IProfileQueryService
{
    public async Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query)
    {
        return await profileRepository.ListAsync();
    }

    public async Task<Profile?> Handle(GetProfileByEmailQuery query)
    {
        return await profileRepository.FindProfileByEmailAsync(query.Email);
    }

    public async Task<Profile?> Handle(GetProfileByIdQuery query)
    {
        return await profileRepository.FindByIdAsync(query.ProfileId);
    }
}
