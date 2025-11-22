using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;

namespace Chaquitaclla_API_TSW.Crops.Domain.Services;

public interface IPestQueryService
{
    Task<Pest?> Handle(GetPestByIdQuery query);
    
    Task<IEnumerable<Pest>> Handle(GetAllPestsQuery query);
    Task<IEnumerable<Pest>> Handle(GetPestByCropIdQuery query);

}
