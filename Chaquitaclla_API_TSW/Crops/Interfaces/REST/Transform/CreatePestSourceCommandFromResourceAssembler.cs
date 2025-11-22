using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;

public static class CreatePestSourceCommandFromResourceAssembler
{
    public static CreatePestCommand ToCommandFromResource(CreatePestResource resource)
    {
        return new CreatePestCommand(resource.Name, resource.Description, resource.Solution);
    }
}
