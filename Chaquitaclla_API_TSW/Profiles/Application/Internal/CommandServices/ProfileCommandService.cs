using Chaquitaclla_API_TSW.Profiles.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Profiles.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Profiles.Domain.Repositories;
using Chaquitaclla_API_TSW.Profiles.Domain.Services;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IProfileCommandService
{
    private IProfileCommandService profileCommandServiceImplementation;

    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }

    public async Task<Profile?> Handle(UpdateProfileCommand command)
    {
        var profile = await profileRepository.GetProfileByIdAsync(command.ProfileId);
        if (profile == null) return null;

        profile.UpdateProfile(
            command.FullName,
            command.EmailAddress,
            command.CountryId,
            command.CityId,
            command.SubscriptionId
        );

        await profileRepository.UpdateProfile(profile);
        return profile;
    }
}
