namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

public record UpdateCropResource (
    int CropId,
    string Name, string Description);