namespace Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(string FirstName, string LastName, string Email, int CityId, int SubscriptionId, int CountryId);
