using Chaquitaclla_API_TSW.Forum.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Forum.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Forum.Interfaces.REST.Transform;

public static class UpdateCategoryCommandFromResourceAssembler
{
    public static UpdateCategoryCommand ToCommandFromResource(int categoryId, UpdateCategoryResource resource)
    {
        return new UpdateCategoryCommand(categoryId, resource.Name);
    }
}
