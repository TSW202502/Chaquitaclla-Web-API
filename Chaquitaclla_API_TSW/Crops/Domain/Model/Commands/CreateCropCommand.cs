namespace Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;



public record CreateCropCommand(string Name, string ImageUrl, string Description, List<int> Diseases, List<int> Pests, List<int> Cares);
