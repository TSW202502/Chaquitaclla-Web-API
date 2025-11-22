using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;

public static class CreateDiseaseSourceCommandFromResourceAssembler
{
    public static CreateDiseaseCommand ToCommandFromResource(CreateDiseaseResource resource)
    {
        return new CreateDiseaseCommand(resource.Name, resource.Description, resource.Solution);
    }
}
