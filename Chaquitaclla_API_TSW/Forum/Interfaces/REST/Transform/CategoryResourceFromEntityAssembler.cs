using Chaquitaclla_API_TSW.Forum.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Forum.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Forum.Interfaces.REST.Transform;

public static class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category entity)
    {
        return new CategoryResource(entity.Id, entity.Name);
    }
}
