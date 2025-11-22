using Chaquitaclla_API_TSW.Profiles.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Transform;

public static class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResourceFromEntity(Subscription subscription)
    {
        return new SubscriptionResource(subscription.Id, subscription.Description, subscription.Price, subscription.Range);
    }
}
