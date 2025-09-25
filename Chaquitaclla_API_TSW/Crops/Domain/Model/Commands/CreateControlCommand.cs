using Chaquitaclla_API_TSW.Crops.Domain.Model.ValueObjects;

namespace Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;

public record CreateControlCommand(ESowingCondition Condition, ESowingSoilMoisture SoilMoisture, ESowingStemCondition StemCondition, int SowingId);