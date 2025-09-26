namespace Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;

public record CreateDiseaseCommand(string Name, string Description, List<int> CropIds);