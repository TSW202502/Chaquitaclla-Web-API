using Chaquitaclla_API_TSW.Forum.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Forum.Domain.Repositories;

public interface IQuestionRepository : IBaseRepository<Question>
{
    Task<IEnumerable<Question>> FindByUserIdAsync(int authorId);
    bool ExistsByQuestionText(string questionText);
}
