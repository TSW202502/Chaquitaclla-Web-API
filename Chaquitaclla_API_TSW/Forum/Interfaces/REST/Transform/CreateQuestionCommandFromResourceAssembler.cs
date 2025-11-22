using Chaquitaclla_API_TSW.Forum.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Forum.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Forum.Interfaces.REST.Transform;

public static class CreateQuestionCommandFromResourceAssembler
{
    public static CreateQuestionCommand ToCommandFromResource(CreateQuestionResource resource)
    {
        return new CreateQuestionCommand(resource.AuthorId, resource.CategoryId, resource.QuestionText, resource.Date);
    }
}
