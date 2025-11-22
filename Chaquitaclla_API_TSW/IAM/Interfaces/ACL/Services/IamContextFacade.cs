using Chaquitaclla_API_TSW.IAM.Domain.Model.Commands;
using Chaquitaclla_API_TSW.IAM.Domain.Model.Queries;
using Chaquitaclla_API_TSW.IAM.Domain.Services;

namespace Chaquitaclla_API_TSW.IAM.Interfaces.ACL.Services;

public class IamContextFacade(
    IUserQueryService userQueryService, 
    IUserCommandService userCommandService) : IIamContextFacade
{
    public async Task<int> CreateUser(string username, string password)
    {
        var signUpCommand = new SignUpCommand(username, password);
        await userCommandService.Handle(signUpCommand);
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.Id ?? 0;
    }

    public async Task<int> FetchUserIdByUsername(string username)
    {
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.Id ?? 0;
    }

    public async Task<string> FetchUsernameByUserId(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var result = await userQueryService.Handle(getUserByIdQuery);
        return result?.Username ?? string.Empty;
    }
}
