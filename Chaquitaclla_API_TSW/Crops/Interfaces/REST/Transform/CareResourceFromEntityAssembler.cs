using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;

public class CareResourceFromEntityAssembler
{
    public static CareResource ToResourceFromEntity(Care entity)
    {
        return new CareResource(entity.Id, entity.Suggestion, entity.Date);
    }
}
