using Chaquitaclla_API_TSW.Profiles.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id, entity.FullName, entity.EmailAddress, entity.CountryId, entity.CityId, entity.SubscriptionId);
    }
}
