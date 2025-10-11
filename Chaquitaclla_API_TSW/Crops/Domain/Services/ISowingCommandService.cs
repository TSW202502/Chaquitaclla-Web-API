using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;

namespace Chaquitaclla_API_TSW.Crops.Domain.Services;

public interface ISowingCommandService
{
    Task<Sowing> Handle(CreateSowingCommand command);
    Task<Sowing> Handle(int id, UpdateSowingCommand command);
    Task<bool> Handle(DeleteSowingCommand command);
    
    Task<Product> Handle(AddProductToSowingCommand command);
    Task<Sowing> Handle(UpdatePhenologicalPhaseBySowingIdCommand command);
}