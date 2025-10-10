using System.Net.Mime;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;
using Chaquitaclla_API_TSW.Crops.Domain.Services;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Chaquitaclla_API_TSW.Crops.Interfaces;


[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SowingsController(ISowingCommandService sowingCommandService,
    ISowingQueryService sowingQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateSowing([FromBody] CreateSowingResource resource)
    {
        var createSowingCommand =
            CreateSowingSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await sowingCommandService.Handle(createSowingCommand);
        return CreatedAtAction(nameof(GetSowingById), new { id = result.Id },
                SowingResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateSowing(int id, [FromBody] UpdateSowingResource resource)
    {
        var updateSowingCommand = UpdateSowingSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await sowingCommandService.Handle(id, updateSowingCommand);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(SowingResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetSowingById(int id)
    {
        var getSowingByIdQuery = new GetSowingByIdQuery(id);
        var result = await sowingQueryService.Handle(getSowingByIdQuery);
        var resource = SowingResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    private async Task<ActionResult> GetSowingByStatusQuery(bool status)
    {
        var getSowingByStatus = new GetSowingByStatusQuery(status);
        var result = await sowingQueryService.Handle(getSowingByStatus);
        var resources = result.Select(SowingResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetSowingsFromQuery([FromQuery] bool? status)
    {
        if (status.HasValue)
        {
            return await GetSowingByStatusQuery(status.Value);
        }
        else
        {
            return Ok();
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteSowing(int id)
    {
        var deleteSowingCommand = new DeleteSowingCommand(id);
        var result = await sowingCommandService.Handle(deleteSowingCommand);
        if (!result)
        {
            return NotFound();
        }
    
        return Ok("Sowing deleted successful!");
    }
}