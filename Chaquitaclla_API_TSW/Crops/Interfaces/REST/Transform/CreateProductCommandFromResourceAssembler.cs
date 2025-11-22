using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Domain.Model.ValueObjects;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;

public static class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        if( Enum.TryParse<EProductType>(resource.Type, out var type))
        {
            return new CreateProductCommand(resource.Name, type);
        }
        else
        {
            throw new ArgumentException("Invalid product type");
        }
    }
}
