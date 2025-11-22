using System.Net.Mime;
using Chaquitaclla_API_TSW.Profiles.Domain.Services;
using Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Resources;
using Chaquitaclla_API_TSW.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Chaquitaclla_API_TSW.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SubscriptionController(ISubscriptionCommandService subscriptionCommandService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateSubscription (CreateSubscriptionResource resource)
    {
        var createSubscriptionCommand = CreateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(resource);
        var subscription = await subscriptionCommandService.Handle(createSubscriptionCommand);
        if (subscription is null) return BadRequest();
        var subscriptionResource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return CreatedAtRoute(new {subscriptionId = subscriptionResource.Id}, subscriptionResource);
    }
}
