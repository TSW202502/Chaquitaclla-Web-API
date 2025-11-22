using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;
public record PestResource(int Id, string Name, string Description, string Solution);
