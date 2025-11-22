using Chaquitaclla_API_TSW.Forum.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Forum.Domain.Model.Queries;
using Chaquitaclla_API_TSW.Forum.Domain.Repositories;
using Chaquitaclla_API_TSW.Forum.Domain.Services;

namespace Chaquitaclla_API_TSW.Forum.Application.QueryService;

public class AnswerQueryService(IAnswerRepository answerRepository) : IAnswerQueryService
{
    public async Task<IEnumerable<Answer>> Handle(GetAllAnswersQuery query)
    {
        return await answerRepository.ListAsync();
    }

    public async Task<Answer?> Handle(GetAnswerByIdQuery query)
    {
        return await answerRepository.FindByIdAsync(query.AnswerId);
    }

    public async Task<IEnumerable<Answer>> Handle(GetAllAnswersByQuestionId query)
    {
        return await answerRepository.FindByQuestionIdAsync(query.QuestionId);
    }
}
