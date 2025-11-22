using Chaquitaclla_API_TSW.Profiles.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Transform;

public static class UpdateProfileCommandFromResourceAssembler
{
    public static UpdateProfileCommand ToCommandFromResource(int profileId, UpdateProfileResource resource)
    {
        return new UpdateProfileCommand(
            profileId,
            resource.FullName,
            resource.EmailAddress,
            resource.CountryId,
            resource.CityId,
            resource.SubscriptionId
        );
    }
}
