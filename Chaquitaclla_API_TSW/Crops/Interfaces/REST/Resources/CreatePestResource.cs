namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

public record CreatePestResource(string Name, string Description, List<int> CropIds);