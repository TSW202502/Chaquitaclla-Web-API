using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Crops.Domain.Services;

namespace Chaquitaclla_API_TSW.Crops.Application.QueryServices;

public class ControlQueryService (IControlRepository controlRepository) : IControlQueryService
{
    public async Task<IEnumerable<Control>> Handle(GetAllControlsQuery query)
    {
        return await controlRepository.ListAsync();
    }
    public async Task<Control?> Handle(GetControlByIdQuery query)
    {
        return await controlRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Control>> Handle(GetAllControlsBySowingIdQuery query)
    {
        return await controlRepository.FindBySowingIdAsync(query.SowingId);
    }
}
