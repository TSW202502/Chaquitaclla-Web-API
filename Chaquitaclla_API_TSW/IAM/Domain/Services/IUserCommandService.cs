using Chaquitaclla_API_TSW.IAM.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.IAM.Domain.Model.Commands;

namespace Chaquitaclla_API_TSW.IAM.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);
    Task<(User user, string token)> Handle(SignInCommand command);
}
