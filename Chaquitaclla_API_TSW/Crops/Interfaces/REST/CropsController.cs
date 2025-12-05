using System.Net.Mime;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;
using Chaquitaclla_API_TSW.Crops.Domain.Services;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST;

/// <summary>
/// Controlador REST para la gestión de cultivos (Crops)
/// </summary>
/// <remarks>
/// Este controlador proporciona endpoints para realizar operaciones CRUD sobre cultivos,
/// incluyendo creación, consulta, actualización y eliminación de cultivos.
/// También incluye funcionalidades relacionadas con siembras (sowings).
/// </remarks>
[ApiController]
[Route("/api/v1/crops-management/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CropsController : ControllerBase
{
    private readonly ICropCommandService cropCommandService;
    private readonly ICropQueryService cropQueryService;
    private readonly ISowingQueryService sowingQueryService;

    public CropsController(ICropCommandService cropCommandService, ICropQueryService cropQueryService, ISowingQueryService sowingQueryService)
    {
        this.cropCommandService = cropCommandService;
        this.cropQueryService = cropQueryService;
        this.sowingQueryService = sowingQueryService;
    }

    /// <summary>
    /// Crea un nuevo cultivo
    /// </summary>
    /// <param name="resource">Datos del cultivo a crear, incluyendo nombre, descripción, URL de imagen, y listas de enfermedades, plagas y cuidados asociados</param>
    /// <returns>El cultivo creado con su ID asignado</returns>
    /// <response code="201">Cultivo creado exitosamente</response>
    /// <response code="400">Solicitud inválida</response>
    [HttpPost]
    [ProducesResponseType(typeof(CropResource), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateCrop([FromBody] CreateCropResource resource)
    {
        var createCropCommand =
            CreateCropSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await cropCommandService.Handle(createCropCommand);
        return CreatedAtAction(nameof(GetCropById), new { id = result.Id },
            CropResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    /// <summary>
    /// Obtiene un cultivo por su ID
    /// </summary>
    /// <param name="id">Identificador único del cultivo</param>
    /// <returns>El cultivo encontrado con toda su información</returns>
    /// <response code="200">Cultivo encontrado exitosamente</response>
    /// <response code="404">Cultivo no encontrado</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CropResource), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetCropById(int id)
    {
        var getCropByIdQuery = new GetCropByIdQuery(id);
        var result = await cropQueryService.Handle(getCropByIdQuery);
        if (result == null)
        {
            return NotFound();
        }
        var resource = CropResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    /// <summary>
    /// Actualiza un cultivo existente
    /// </summary>
    /// <param name="id">Identificador único del cultivo a actualizar</param>
    /// <param name="resource">Datos actualizados del cultivo (nombre y descripción)</param>
    /// <returns>El cultivo actualizado</returns>
    /// <response code="200">Cultivo actualizado exitosamente</response>
    /// <response code="404">Cultivo no encontrado</response>
    /// <response code="400">Solicitud inválida</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(CropResource), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateCrop(int id, [FromBody] UpdateCropResource resource)
    {
        var updateCropCommand = UpdateCropSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await cropCommandService.Handle(id, updateCropCommand);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(CropResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    /// <summary>
    /// Obtiene todos los cultivos disponibles
    /// </summary>
    /// <returns>Lista de todos los cultivos registrados en el sistema</returns>
    /// <response code="200">Lista de cultivos obtenida exitosamente (puede estar vacía)</response>
    /// <response code="400">Error al procesar la solicitud</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CropResource>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCrops()
    {
        try
        {
            var getAllCropsQuery = new GetAllCropsQuery();
            var crops = await cropQueryService.Handle(getAllCropsQuery);
            if (crops == null)
            {
                return Ok(new List<CropResource>());
            }
            var resources = crops.Select(CropResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving crops: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>
    /// Elimina un cultivo por su ID
    /// </summary>
    /// <param name="id">Identificador único del cultivo a eliminar</param>
    /// <returns>El cultivo eliminado</returns>
    /// <response code="200">Cultivo eliminado exitosamente</response>
    /// <response code="404">Cultivo no encontrado</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(CropResource), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCrop(int id)
    {
        var result = await cropCommandService.DeleteCrop(id);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(CropResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    /*[HttpPost("sowings")]
    public async Task<ActionResult> CreateSowingFromCrop([FromBody] CreateSowingResource resource)
    {
        var createSowingCommand = CreateSowingSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await cropCommandService.HandleCreateSowing(createSowingCommand);
        return CreatedAtAction(nameof(GetCropById), new { id = result.Id },
            SowingResourceFromEntityAssembler.ToResourceFromEntity(result));
    }*/
    
    
    /// <summary>
    /// Obtiene una siembra por su ID
    /// </summary>
    /// <param name="id">Identificador único de la siembra</param>
    /// <returns>La siembra encontrada con toda su información</returns>
    /// <response code="200">Siembra encontrada exitosamente</response>
    /// <response code="400">Error al procesar la solicitud</response>
    [HttpGet("sowings/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetSowingById(int id)
    {
        try
        {
            var getSowingByIdQuery = new GetSowingByIdQuery(id);
            var sowing = await sowingQueryService.Handle(getSowingByIdQuery);
            var resource = SowingResourceFromEntityAssembler.ToResourceFromEntity(sowing);
            return Ok(resource);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving sowing: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
    }

}
