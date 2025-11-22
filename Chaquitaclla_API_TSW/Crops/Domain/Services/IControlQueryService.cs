using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;

namespace Chaquitaclla_API_TSW.Crops.Domain.Services;

public interface IControlQueryService
{
    Task<IEnumerable<Control>> Handle(GetAllControlsQuery query);
    Task<Control?> Handle(GetControlByIdQuery query);
    
    Task<IEnumerable<Control>> Handle(GetAllControlsBySowingIdQuery query);
}
