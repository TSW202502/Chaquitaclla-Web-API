using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform
{
    public static class PestResourceFromEntityAssembler
    {
        public static PestResource ToResourceFromEntity(Pest entity)
        {
            return new PestResource(entity.Id, entity.Name, entity.Description);
            
        }
    }
}