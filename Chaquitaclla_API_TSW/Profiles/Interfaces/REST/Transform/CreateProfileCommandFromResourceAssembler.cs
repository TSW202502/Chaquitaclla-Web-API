using Chaquitaclla_API_TSW.Profiles.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.FirstName, resource.LastName, resource.Email
            , resource.CountryId, resource.CityId, resource.SubscriptionId);
    }
}
