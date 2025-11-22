using Chaquitaclla_API_TSW.Forum.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Forum.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Forum.Interfaces.REST.Transform;

public static class CreateAnswerCommandFromResourceAssembler
{
    public static CreateAnswerCommand ToCommandFromResource(CreateAnswerResource resource)
    {
        return new CreateAnswerCommand(resource.AuthorId, resource.QuestionId, resource.AnswerText);
    }
}
