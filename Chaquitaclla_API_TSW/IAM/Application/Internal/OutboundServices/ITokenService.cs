using Chaquitaclla_API_TSW.IAM.Domain.Model.Aggregates;

namespace Chaquitaclla_API_TSW.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}
