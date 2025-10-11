using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;

namespace Chaquitaclla_API_TSW.Crops.Domain.Services;

public interface IPestCommandService
{
    Task<Pest> Handle(CreatePestCommand command);
}