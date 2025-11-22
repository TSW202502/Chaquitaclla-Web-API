namespace Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Resources;

public record ProfileResource(int Id, string FullName, string Email, int CountryId, int CityId, int SubscriptionId);
