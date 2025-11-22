using Chaquitaclla_API_TSW.Forum.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Forum.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Forum.Interfaces.REST.Transform;

public class UpdateAnswerCommandFromResourceAssembler
{
    public static UpdateAnswerCommand ToCommandFromResource(int answerId,UpdateAnswerResource resource)
    {
        return new UpdateAnswerCommand(answerId,resource.AnswerText);
    }
}
