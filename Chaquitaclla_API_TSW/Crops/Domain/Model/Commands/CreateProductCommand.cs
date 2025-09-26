using Chaquitaclla_API_TSW.Crops.Domain.Model.ValueObjects;

namespace Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;

public record CreateProductCommand(String Name, EProductType Type);