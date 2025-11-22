using Chaquitaclla_API_TSW.Forum.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Forum.Domain.Model.Entities;

namespace Chaquitaclla_API_TSW.Forum.Domain.Services;

public interface ICategoryCommandService
{
    Task<Category?> Handle(CreateCategoryCommand command);
    Task<Category> Handle(UpdateCategoryCommand command);
    Task Handle(DeleteCategoryCommand command);
}
