using Chaquitaclla_API_TSW.Profiles.Domain.Model.ValueObjects;

namespace Chaquitaclla_API_TSW.Profiles.Domain.Model.Commands;

public record CreateSubscriptionCommand(string Description, decimal Price, int Range);
