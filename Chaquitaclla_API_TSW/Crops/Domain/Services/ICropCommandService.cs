using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;

namespace Chaquitaclla_API_TSW.Crops.Domain.Services;

public interface ICropCommandService
{
    Task<Crop> Handle(CreateCropCommand command);
    
    Task<Crop> Handle(int id, UpdateCropCommand command);

    Task<Sowing> CreateSowingFromCrop(int id);
    Task<Crop> DeleteCrop(int id);
    Task<Sowing> HandleCreateSowing(CreateSowingCommand createSowingCommand);
}
