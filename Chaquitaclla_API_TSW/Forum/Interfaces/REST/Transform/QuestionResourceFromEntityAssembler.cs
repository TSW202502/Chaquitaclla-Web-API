using Chaquitaclla_API_TSW.Forum.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Forum.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Forum.Interfaces.REST.Transform;

public static class QuestionResourceFromEntityAssembler
{
    public static QuestionResource ToResourceFromEntity(Question entity)
    {
        if (entity.QuestionText == null)
        {
            throw new ArgumentNullException(nameof(entity), "La entidad Question proporcionada no puede ser null.");
        }

        if (entity.CategoryId == null)
        {
            throw new ArgumentNullException(nameof(entity.AuthorId), "La propiedad AuthorId de la entidad Question no puede ser null.");
        }
        
        return new QuestionResource( 
            entity.Id,
            entity.AuthorId.Id,
            entity.CategoryId,
            entity.QuestionText,
            entity.Date
            );
    }
}
