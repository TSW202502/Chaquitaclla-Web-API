namespace Chaquitaclla_API_TSW.Forum.Domain.Model.Commands;

public record UpdateQuestionCommand(int QuestionId, int CategoryId, string QuestionText);
