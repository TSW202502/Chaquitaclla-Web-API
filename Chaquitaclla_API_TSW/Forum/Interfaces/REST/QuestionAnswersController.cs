using System.Net.Mime;
using Chaquitaclla_API_TSW.Forum.Domain.Model.Queries;
using Chaquitaclla_API_TSW.Forum.Domain.Services;
using Chaquitaclla_API_TSW.Forum.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Chaquitaclla_API_TSW.Forum.Interfaces.REST;

[ApiController]
[Route("api/v1/forum/")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Answers")]
public class QuestionAnswersController(IAnswerCommandService answerCommandService, IAnswerQueryService answerQueryService) : ControllerBase
{
    [HttpGet("question/{questionId}/answers")]
    public async Task<ActionResult> GetAnswersByQuestionId([FromRoute] int questionId)
    {
        var getAllAnswersByQuestionIdQuery = new GetAllAnswersByQuestionId(questionId);
        var answers = await answerQueryService.Handle(getAllAnswersByQuestionIdQuery);
        var resources = answers.Select(AnswerResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}
