using Chaquitaclla_API_TSW.Profiles.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Profiles.Domain.Model.Entities;

namespace Chaquitaclla_API_TSW.Profiles.Domain.Services;

public interface ISubscriptionCommandService
{
    Task<Subscription?> Handle(CreateSubscriptionCommand command);
}
