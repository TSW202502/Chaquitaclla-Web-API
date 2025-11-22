using Chaquitaclla_API_TSW.Forum.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Forum.Domain.Model.Queries;
using Chaquitaclla_API_TSW.Forum.Domain.Repositories;
using Chaquitaclla_API_TSW.Forum.Domain.Services;


namespace Chaquitaclla_API_TSW.Forum.Application.QueryService;

public class CategoryQueryService(ICategoryRepository categoryRepository) : ICategoryQueryService
{
    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query)
    {
        return await categoryRepository.ListAsync();
    }

    public async Task<Category?> Handle(GetCategoryByIdQuery query)
    {
        return await categoryRepository.FindByIdAsync(query.CategoryId);
    }
}
