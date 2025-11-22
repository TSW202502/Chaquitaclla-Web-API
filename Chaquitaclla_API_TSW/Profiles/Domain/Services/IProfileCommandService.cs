using Chaquitaclla_API_TSW.Profiles.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Profiles.Domain.Model.Commands;

namespace Chaquitaclla_API_TSW.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);

    Task<Profile?> Handle(UpdateProfileCommand command);
}
