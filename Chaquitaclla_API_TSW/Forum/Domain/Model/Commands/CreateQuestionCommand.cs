namespace Chaquitaclla_API_TSW.Forum.Domain.Model.Commands;

public record CreateQuestionCommand(int AuthorId, int CategoryId, string QuestionText, DateTime Date);
