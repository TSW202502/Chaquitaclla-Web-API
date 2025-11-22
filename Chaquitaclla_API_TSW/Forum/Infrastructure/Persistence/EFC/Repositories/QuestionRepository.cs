using Chaquitaclla_API_TSW.Forum.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Forum.Domain.Repositories;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Configuration;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chaquitaclla_API_TSW.Forum.Infrastructure.Persistence.EFC.Repositories;

public class QuestionRepository(AppDbContext context) : BaseRepository<Question>(context), IQuestionRepository
{
    public async Task<IEnumerable<Question>> FindByUserIdAsync(int authorId)
    {
        return await Context.Set<Question>().Where(q => q.AuthorId.Id == authorId).ToListAsync();
    }

    public bool ExistsByQuestionText(string questionText)
    {
        return Context.Set<Question>().Any(q=>q.QuestionText == questionText);
    }
}
