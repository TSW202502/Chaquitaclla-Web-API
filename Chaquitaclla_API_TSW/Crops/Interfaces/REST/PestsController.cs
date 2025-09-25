using System.Net.Mime;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;
using Chaquitaclla_API_TSW.Crops.Domain.Services;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PestsController : ControllerBase
{
    private readonly IPestCommandService pestCommandService;
    private readonly IPestQueryService pestQueryService;

    public PestsController(IPestCommandService pestCommandService, IPestQueryService pestQueryService)
    {
        this.pestCommandService = pestCommandService;
        this.pestQueryService = pestQueryService;
    }

    [HttpPost]
    public async Task<ActionResult> CreatePest([FromBody] CreatePestResource resource)
    {
        var createPestCommand = CreatePestSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await pestCommandService.Handle(createPestCommand);
        return CreatedAtAction(nameof(GetPestById), new { id = result.Id },
            PestResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetPestById(int id)
    {
        var getPestByIdQuery = new GetPestByIdQuery(id);
        var result = await pestQueryService.Handle(getPestByIdQuery);
        var resource = PestResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}