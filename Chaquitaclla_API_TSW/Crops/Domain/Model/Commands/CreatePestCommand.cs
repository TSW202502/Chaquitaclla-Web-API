namespace Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;

public record CreatePestCommand(string Name, string Description, List<int> CropIds);