using Chaquitaclla_API_TSW.IAM.Domain.Model.Commands;
using Chaquitaclla_API_TSW.IAM.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }

}
