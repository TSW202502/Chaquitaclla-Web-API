using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Domain.Model.ValueObjects;

namespace Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;

public class Controls
{
    public int Id { get; }
    
    public int SowingId { get; private set; }
    
    public Sowing Sowing { get; private set; }
    
    public ESowingCondition Condition { get; private set; }
    
    public ESowingSoilMoisture SoilMoisture { get; private set; }
    
    public ESowingStemCondition StemCondition { get; private set; }
    
    public Controls(CreateControlCommand command)
    {
        SowingId = command.SowingId;
        Condition = command.Condition;
        SoilMoisture = command.SoilMoisture;
        StemCondition = command.StemCondition;
    }
    
}