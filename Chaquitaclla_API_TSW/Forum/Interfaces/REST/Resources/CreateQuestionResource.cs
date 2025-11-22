namespace Chaquitaclla_API_TSW.Forum.Interfaces.REST.Resources;

public record CreateQuestionResource(int AuthorId ,int CategoryId, string QuestionText, DateTime Date);
