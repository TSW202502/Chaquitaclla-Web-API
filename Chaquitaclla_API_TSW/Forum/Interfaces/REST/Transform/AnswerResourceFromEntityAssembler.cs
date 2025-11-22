using Chaquitaclla_API_TSW.Forum.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Forum.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Forum.Interfaces.REST.Transform;

public static class AnswerResourceFromEntityAssembler
{
    public static AnswerResource ToResourceFromEntity(Answer entity)
    {
        return new AnswerResource(
            entity.Id,
            entity.AuthorId.Id,
            entity.QuestionId,
            entity.AnswerText
        );
    }
}
