using Chaquitaclla_API_TSW.Crops.Domain.Model.ValueObjects;

namespace Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;

public record UpdateControlCommand(int Id, int SowingId, ESowingCondition SowingCondition, ESowingStemCondition StemCondition, ESowingSoilMoisture SoilMoisture);
