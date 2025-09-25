using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;

namespace Chaquitaclla_API_TSW.Crops.Domain.Services;

public interface ISowingCommandService
{
    Task<Sowing> Handle(CreateSowingCommand command);
    Task<Sowing> Handle(int id, UpdateSowingCommand command);
}