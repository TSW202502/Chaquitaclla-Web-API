using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;

namespace Chaquitaclla_API_TSW.Crops.Domain.Services;

public interface ICropCommandService
{
    Task<Crop> Handle(CreateCropCommand command);
}