using Chaquitaclla_API_TSW.Profiles.Domain.Model.ValueObjects;

namespace Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Resources;

public record SubscriptionResource(int Id, string Description, decimal Price, int Range);
