namespace Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;

public record UpdateCropCommand(int CropId, string Name, string Description);