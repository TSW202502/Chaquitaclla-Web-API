using Chaquitaclla_API_TSW.Forum.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Forum.Domain.Model.Queries;

namespace Chaquitaclla_API_TSW.Forum.Domain.Services;

public interface IQuestionQueryService
{
    Task<IEnumerable<Question>> Handle(GetAllQuestionsQuery query);
    Task<Question?> Handle(GetQuestionByIdQuery query);
    Task<IEnumerable<Question>> Handle(GetAllQuestionsByUserId query);
}
