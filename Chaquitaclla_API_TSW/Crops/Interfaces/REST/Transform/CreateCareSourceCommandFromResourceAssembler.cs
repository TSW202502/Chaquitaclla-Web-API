using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;

public static class CreateCareSourceCommandFromResourceAssembler
{
    public static CreateCareCommand ToCommandFromResource(CreateCareResource resource)
    {
        return new CreateCareCommand(resource.Suggestion, resource.Date);
    }
}

