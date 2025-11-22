namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

public record ControlResource(int Id,int SowingId, DateTime Date ,string SowingCondition, string StemCondition, string SoilMoisture);
