using Chaquitaclla_API_TSW.IAM.Domain.Model.Commands;
using Chaquitaclla_API_TSW.IAM.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}
