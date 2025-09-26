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
public class DiseasesController : ControllerBase
{
    private readonly IDiseaseCommandService diseaseCommandService;
    private readonly IDiseaseQueryService diseaseQueryService;

    public DiseasesController(IDiseaseCommandService diseaseCommandService,
        IDiseaseQueryService diseaseQueryService)
    {
        this.diseaseCommandService = diseaseCommandService;
        this.diseaseQueryService = diseaseQueryService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateDisease([FromBody] CreateDiseaseResource resource)
    {
        var createDiseaseCommand =
            CreateDiseaseSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await diseaseCommandService.Handle(createDiseaseCommand);
        return CreatedAtAction(nameof(GetDiseaseById), new { id = result.Id },
            DiseaseResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetDiseaseById(int id)
    {
        var getDiseaseByIdQuery= new GetDiseaseByIdQuery(id);
        var result = await diseaseQueryService.Handle(getDiseaseByIdQuery);
        var resource = DiseaseResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}