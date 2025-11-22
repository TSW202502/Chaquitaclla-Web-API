using Chaquitaclla_API_TSW.Forum.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Forum.Domain.Model.Commands;

namespace Chaquitaclla_API_TSW.Forum.Domain.Services;

public interface IQuestionCommandService
{
    Task<Question?> Handle(CreateQuestionCommand command);
    Task<Question> Handle(UpdateQuestionCommand command);
    Task Handle(DeleteQuestionCommand command);
}
