using Chaquitaclla_API_TSW.Forum.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Forum.Domain.Model.ValueObjects;
using Chaquitaclla_API_TSW.Forum.Domain.Repositories;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Configuration;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chaquitaclla_API_TSW.Forum.Infrastructure.Persistence.EFC.Repositories;

public class AnswerRepository(AppDbContext context) : BaseRepository<Answer>(context), IAnswerRepository
{
    public async Task<IEnumerable<Answer>> FindByQuestionIdAsync(int questionId)
    {
        return await Context.Set<Answer>().Where(a => a.QuestionId == questionId).ToListAsync();
    }

    public bool ExistsByAnswerTextAndAuthorId(string answerText, UserId authorId)
    {
        return Context.Set<Answer>().Any(a => a.AnswerText == answerText && a.AuthorId == authorId);
    }
}
