using Chaquitaclla_API_TSW.Forum.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Forum.Domain.Model.Queries;
using Chaquitaclla_API_TSW.Forum.Domain.Repositories;
using Chaquitaclla_API_TSW.Forum.Domain.Services;

namespace Chaquitaclla_API_TSW.Forum.Application.QueryService;

public class QuestionQueryService(IQuestionRepository questionRepository) : IQuestionQueryService
{
    public async Task<IEnumerable<Question>> Handle(GetAllQuestionsQuery query)
    {
        return await questionRepository.ListAsync();
    }

    public async Task<Question?> Handle(GetQuestionByIdQuery query)
    {
        return await questionRepository.FindByIdAsync(query.QuestionId);
    }

    public async Task<IEnumerable<Question>> Handle(GetAllQuestionsByUserId query)
    {
        return await questionRepository.FindByUserIdAsync(query.AuthorId);
    }
}
