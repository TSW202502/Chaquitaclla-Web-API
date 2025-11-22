using Chaquitaclla_API_TSW.Forum.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Forum.Domain.Model.Queries;

namespace Chaquitaclla_API_TSW.Forum.Domain.Services;

public interface IAnswerQueryService
{
    Task<IEnumerable<Answer>> Handle(GetAllAnswersQuery query);
    Task<Answer?> Handle(GetAnswerByIdQuery query);
    Task<IEnumerable<Answer>> Handle(GetAllAnswersByQuestionId query);
}
