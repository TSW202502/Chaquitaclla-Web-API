using System.Net.Mime;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;
using Chaquitaclla_API_TSW.Crops.Domain.Services;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST;


[ApiController]
[Route("/api/v1/crops-management/crops")]
[Produces(MediaTypeNames.Application.Json)]
public class CropCaresController : ControllerBase
{
    private readonly ICareCommandService careCommandService;
    private readonly ICareQueryService careQueryService;

    public CropCaresController(ICareCommandService careCommandService,
        ICareQueryService careQueryService)
    {
        this.careCommandService = careCommandService;
        this.careQueryService= careQueryService;
    }

    [HttpPost("cares")]
    public async Task<ActionResult> CreateCare([FromBody] CreateCareResource resource)
    {
        var createCareCommand =
            CreateCareSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await careCommandService.Handle(createCareCommand);
        return CreatedAtAction(nameof(GetCareById), new { id = result.Id },
            CareResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("cares/{id}")]
    public async Task<ActionResult> GetCareById(int id)
    {
        var getCareByIdQuery = new GetCareByIdQuery(id);
        var result = await careQueryService.Handle(getCareByIdQuery);
        var resource = CareResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet("{cropId}/cares")]
    public async Task<ActionResult> GetCaresByCropId(int cropId)
    {
        try
        {
            var getCaresByCropIdQuery = new GetCareByCropIdQuery(cropId);
            var cares = await careQueryService.Handle(getCaresByCropIdQuery);

            if (cares == null)
            {
                return NotFound($"No cares found for crop with id {cropId}");
            }

            var resources = cares.Select(CareResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving cares for crop {cropId}: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
    }
}
