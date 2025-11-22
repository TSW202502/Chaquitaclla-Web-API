namespace Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;

public record AddProductToSowingCommand(
    int SowingId,
    int ProductId,
    int Quantity,
    DateTime UseDate
    );
