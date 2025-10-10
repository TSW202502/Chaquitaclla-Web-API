using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;

namespace Chaquitaclla_API_TSW.Crops.Domain.Services;

public interface ICareQueryService
{
    Task<Care?> Handle(GetCareByIdQuery query);
    
    Task<IEnumerable<Care>> Handle(GetCareByCropIdQuery query);
}