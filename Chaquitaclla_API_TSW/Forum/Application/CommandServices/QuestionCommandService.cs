using Chaquitaclla_API_TSW.Forum.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Forum.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Forum.Domain.Repositories;
using Chaquitaclla_API_TSW.Forum.Domain.Services;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Forum.Application.CommandServices;

public class QuestionCommandService(IQuestionRepository questionRepository,ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : IQuestionCommandService
{
    public async Task<Question?> Handle(CreateQuestionCommand command)
    {
        if(questionRepository.ExistsByQuestionText(command.QuestionText)) 
            throw new Exception("Question already exists");
        var category = await categoryRepository.FindByIdAsync(command.CategoryId);
        if(category is null) throw new Exception("Category not found");
        var question = new Question(command);
        question.Category = category;
        try
        {
            await questionRepository.AddAsync(question);
            await unitOfWork.CompleteAsync();
            return question;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the question: {e.Message}");
            return null;
        }
    }
    

    public async Task<Question> Handle(UpdateQuestionCommand command)
    {
        var question = await questionRepository.FindByIdAsync(command.QuestionId);
        if(question is null) throw new Exception("Question not found");
        var category = await categoryRepository.FindByIdAsync(command.CategoryId);
        if(category is null) throw new Exception("Category not found");
        
        question.UpdateInformation(command);
        try
        {
            questionRepository.Update(question);
            await unitOfWork.CompleteAsync();
            return question;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while trying to update the question: {e.Message}");
            return null;
        }
    }

    public async Task Handle(DeleteQuestionCommand command)
    {
        var question = await questionRepository.FindByIdAsync(command.QuestionId);
        if(question is null) throw new Exception("Question not found");
        try
        {
            questionRepository.Remove(question);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while trying to delete the question: {e.Message}");
        }
        
        
    }
}
