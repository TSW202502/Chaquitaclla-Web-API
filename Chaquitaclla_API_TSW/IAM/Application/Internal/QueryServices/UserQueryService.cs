using Chaquitaclla_API_TSW.IAM.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.IAM.Domain.Model.Queries;
using Chaquitaclla_API_TSW.IAM.Domain.Repositories;
using Chaquitaclla_API_TSW.IAM.Domain.Services;

namespace Chaquitaclla_API_TSW.IAM.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }

    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindByUsernameAsync(query.Username);
    }
}
