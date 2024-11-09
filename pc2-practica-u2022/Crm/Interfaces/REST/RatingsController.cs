using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using pc2_practica_u2022.Crm.Domain.Services;
using pc2_practica_u2022.Crm.Interfaces.REST.Resources;
using pc2_practica_u2022.Crm.Interfaces.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace pc2_practica_u2022.Crm.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Ratings")]
public class RatingsController : ControllerBase
{
    private readonly IRatingCommandService _ratingCommandService;

    public RatingsController(IRatingCommandService ratingCommandService)
    {
        _ratingCommandService = ratingCommandService;
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new rating",
        Description = "Create a new rating",
        OperationId = "CreateRating")]
    [SwaggerResponse(StatusCodes.Status201Created, "The rating was created", typeof(RatingResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The rating could not be created")]
    public async Task<ActionResult> CreateRating([FromBody] CreateRatingResource resource)
    {
        var createRatingCommand = CreateRatingCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        var result = await _ratingCommandService.Handle(createRatingCommand);
        
        if (result is null)
            return BadRequest();
        
        return Created(string.Empty, RatingResourceFromEntityAssembler.toResourceFromEntity(result));
    }
}