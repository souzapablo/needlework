using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeedleWork.Application.Features.Purchases.Commands.Create;

namespace NeedleWork.API.Controllers;

[ApiController]
[Route("api/v1/purchases")]
public class PurchasesController : ControllerBase
{
    private readonly IMediator _mediator;

    public PurchasesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePurchase(CreatePurchaseCommand command)
    {
        long id = await _mediator.Send(command);
        return Ok(id);
    }
}
