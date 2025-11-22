using Chaquitaclla_API_TSW.Forum.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Forum.Domain.Model.ValueObjects;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Forum.Domain.Repositories;

public interface IAnswerRepository : IBaseRepository<Answer>
{
    Task<IEnumerable<Answer>> FindByQuestionIdAsync(int questionId);
    bool ExistsByAnswerTextAndAuthorId(string answerText, UserId authorId);
}
