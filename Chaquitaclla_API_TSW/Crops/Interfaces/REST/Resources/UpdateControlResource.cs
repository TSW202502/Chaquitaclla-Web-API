using Chaquitaclla_API_TSW.Crops.Domain.Model.ValueObjects;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

public record UpdateControlResource(ESowingCondition SowingCondition, ESowingSoilMoisture SoilMoisture, ESowingStemCondition StemCondition);