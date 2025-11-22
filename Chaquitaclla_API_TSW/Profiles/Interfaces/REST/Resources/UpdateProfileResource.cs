namespace Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Resources;

public record UpdateProfileResource(string FullName, string EmailAddress, int CountryId, int CityId, int SubscriptionId);
