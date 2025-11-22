namespace Chaquitaclla_API_TSW.Forum.Interfaces.REST.Resources;

public record CreateAnswerResource(int AuthorId, int QuestionId, string AnswerText);
