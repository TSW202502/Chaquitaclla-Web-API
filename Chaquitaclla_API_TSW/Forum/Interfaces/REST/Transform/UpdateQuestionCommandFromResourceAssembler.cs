using Chaquitaclla_API_TSW.Forum.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Forum.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Forum.Interfaces.REST.Transform;

public class UpdateQuestionCommandFromResourceAssembler
{
    public static UpdateQuestionCommand ToCommandFromResource(int questionId,UpdateQuestionResource resource)
    {
        return new UpdateQuestionCommand(questionId, resource.CategoryId, resource.QuestionText);
    }
}
