using Chaquitaclla_API_TSW.Forum.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Forum.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Forum.Domain.Repositories;
using Chaquitaclla_API_TSW.Forum.Domain.Services;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Forum.Application.CommandServices;

public class CategoryCommandService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : ICategoryCommandService
{
    public async Task<Category?> Handle(CreateCategoryCommand command)
    {
        if(categoryRepository.ExistsByCategoryName(command.Name)) 
            throw new Exception("Category already exists");
        var category = new Category(command);
        try
        {
            await categoryRepository.AddAsync(category);
            await unitOfWork.CompleteAsync();
            return category;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the category: {e.Message}");
            return null;
        }
    }

    public async Task<Category> Handle(UpdateCategoryCommand command)
    {
        var category = await categoryRepository.FindByIdAsync(command.CategoryId);
        if(category is null) throw new Exception("Category not found");
        category.UpdateInformation(command);
        try
        {
            categoryRepository.Update(category);
            await unitOfWork.CompleteAsync();
            return category;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while trying to update the category: {e.Message}");
            throw;
        }
    }

    public async Task Handle(DeleteCategoryCommand command)
    {
        var category = await categoryRepository.FindByIdAsync(command.CategoryId);
        if(category is null) throw new Exception("Category not found");
        try
        {
            categoryRepository.Remove(category);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while trying to delete the category: {e.Message}");
            throw;
        }
    }
}
