namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

public record AddProductToSowingResource(
    int SowingId,
    int ProductId,
    int Quantity
    );