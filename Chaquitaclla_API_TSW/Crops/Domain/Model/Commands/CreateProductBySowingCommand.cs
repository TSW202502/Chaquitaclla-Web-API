namespace Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;

public record CreateProductBySowingCommand(int SowingId, int ProductId, int Quantity);