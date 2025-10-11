using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;

namespace Chaquitaclla_API_TSW.Crops.Domain.Services;

public interface IControlCommandService
{
    Task<Control> Handle(CreateControlCommand command);
    
    Task<Control> Handle(DeleteControlCommand command);

    Task<Control> Handle(UpdateControlCommand command);
}