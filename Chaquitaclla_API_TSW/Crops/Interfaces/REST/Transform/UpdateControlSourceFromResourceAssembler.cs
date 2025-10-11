using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;

public class UpdateControlSourceFromResourceAssembler
{
    public static UpdateControlCommand ToCommandFromResource(UpdateControlResource resource,int sowingId, int sowingControlId ) {
        return new UpdateControlCommand(
            sowingId,
            sowingControlId,
            resource.SowingCondition,
            resource.StemCondition,
            resource.SoilMoisture
        );
    }
}