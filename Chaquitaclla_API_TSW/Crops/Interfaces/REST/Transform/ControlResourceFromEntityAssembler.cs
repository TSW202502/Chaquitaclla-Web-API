using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;

public static class ControlResourceFromEntityAssembler
{
    public static ControlResource ToResourceFromEntity(Control entity)
    {
        return new ControlResource(entity.Id, entity.SowingId,  entity.Date, entity.SowingCondition.ToString(),entity.StemCondition.ToString(), entity.SoilMoisture.ToString());
    }
}
