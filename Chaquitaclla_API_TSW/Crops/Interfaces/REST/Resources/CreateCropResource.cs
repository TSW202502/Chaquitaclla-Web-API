namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

public record CreateCropResource(string Name, string ImageUrl, string Description, List<int> Diseases, List<int> Pests, List<int> Cares);