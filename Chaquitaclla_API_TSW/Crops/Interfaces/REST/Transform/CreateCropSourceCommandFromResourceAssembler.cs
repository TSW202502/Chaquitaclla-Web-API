using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;

public static class CreateCropSourceCommandFromResourceAssembler
{
    public static CreateCropCommand ToCommandFromResource(CreateCropResource resource)
    {
        return new CreateCropCommand(resource.Name, resource.ImageUrl, resource.Description,resource.Diseases,resource.Pests, resource.Cares);
    }
}
