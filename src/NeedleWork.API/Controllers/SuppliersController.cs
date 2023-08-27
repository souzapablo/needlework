using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeedleWork.Application.Features.Suppliers.Commands.Create;

namespace NeedleWork.API.Controllers;

[ApiController]
[Route("api/v1/suppliers")]
public class SuppliersController : ControllerBase
{
    private readonly IMediator _mediator;

    public SuppliersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSupplierAsync([FromBody] CreateSupplierCommand command)
    {
        long id = await _mediator.Send(command);

        return Ok(id);
    }
}