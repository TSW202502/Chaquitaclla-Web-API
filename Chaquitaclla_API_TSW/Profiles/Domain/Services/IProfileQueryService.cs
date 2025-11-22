using Chaquitaclla_API_TSW.Profiles.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Profiles.Domain.Model.Querys;

namespace Chaquitaclla_API_TSW.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
    Task<Profile?> Handle(GetProfileByEmailQuery query);
    Task<Profile?> Handle(GetProfileByIdQuery query);
}
