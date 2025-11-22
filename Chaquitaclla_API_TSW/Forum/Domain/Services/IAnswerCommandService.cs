using Chaquitaclla_API_TSW.Forum.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Forum.Domain.Model.Entities;

namespace Chaquitaclla_API_TSW.Forum.Domain.Services;

public interface IAnswerCommandService
{
    Task<Answer?> Handle(CreateAnswerCommand command);
    Task<Answer> Handle(UpdateAnswerCommand command);
    Task Handle(DeleteAnswerCommand command);
}
