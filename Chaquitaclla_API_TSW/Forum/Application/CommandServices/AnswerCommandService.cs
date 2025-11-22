using Chaquitaclla_API_TSW.Forum.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Forum.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Forum.Domain.Model.ValueObjects;
using Chaquitaclla_API_TSW.Forum.Domain.Repositories;
using Chaquitaclla_API_TSW.Forum.Domain.Services;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Forum.Application.CommandServices;

public class AnswerCommandService(IAnswerRepository answerRepository, IQuestionRepository questionRepository, IUnitOfWork unitOfWork) : IAnswerCommandService
{
    public async Task<Answer?> Handle(CreateAnswerCommand command)
    {
        //TODO: Implement with profile bounded context is ready
        /*if(answerRepository.ExistsByAnswerTextAndAuthorId(command.AnswerText, new UserId(command.AuthorId))) 
            throw new Exception("Answer already exists");
            */
        
        var answer = new Answer(command);
        var question = await questionRepository.FindByIdAsync(command.QuestionId);
        if(question is null) throw new Exception("Question not found");
        answer.Question = question;
        try
        {
            await answerRepository.AddAsync(answer);
            await unitOfWork.CompleteAsync();
            return answer;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the answer: {e.Message}");
            return null;
        }
    }

    public async Task<Answer> Handle(UpdateAnswerCommand command)
    {
        var answer = await answerRepository.FindByIdAsync(command.AnswerId);
        if(answer is null) throw new Exception("Answer not found");
        answer.UpdateInformation(command);
        try
        {
            answerRepository.Update(answer);
            await unitOfWork.CompleteAsync();
            return answer;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while trying to update the answer: {e.Message}");
            throw;
        }
    }

    public async Task Handle(DeleteAnswerCommand command)
    {
        var answer = await answerRepository.FindByIdAsync(command.AnswerId);
        if(answer is null) throw new Exception("Answer not found");
        try
        {
            answerRepository.Remove(answer);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while trying to delete the answer: {e.Message}");
            throw;
        }
    }
}
