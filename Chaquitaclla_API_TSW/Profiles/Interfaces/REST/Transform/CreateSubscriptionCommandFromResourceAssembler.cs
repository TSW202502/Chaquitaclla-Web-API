using Chaquitaclla_API_TSW.Profiles.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Transform;

public static class CreateSubscriptionCommandFromResourceAssembler
{
    public static CreateSubscriptionCommand ToCommandFromResource(CreateSubscriptionResource resource)
    {
        return new CreateSubscriptionCommand(resource.Description, resource.Price, resource.Range);
    }
}
