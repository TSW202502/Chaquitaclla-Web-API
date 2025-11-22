namespace Chaquitaclla_API_TSW.Forum.Interfaces.REST.Resources;

public record QuestionResource(int QuestionId, int AuthorId, int CategoryId, string QuestionText, DateTime Date);
