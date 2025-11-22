namespace Chaquitaclla_API_TSW.Forum.Interfaces.REST.Resources;

public record AnswerResource(int AnswerId, int AuthorId, int QuestionId, string AnswerText);
