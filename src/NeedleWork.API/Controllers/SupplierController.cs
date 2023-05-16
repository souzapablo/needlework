using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeedleWork.Application.Features.Suppliers.Commands.Create;
using NeedleWork.Application.Features.Suppliers.Commands.Delete;
using NeedleWork.Application.Features.Suppliers.Commands.Update;
using NeedleWork.Application.Features.Suppliers.Queries.GetAll;
using NeedleWork.Application.Features.Suppliers.Queries.GetById;
using NeedleWork.Application.InputModels.Suppliers;

namespace NeedleWork.API.Controllers;

[ApiController]
[Route("api/v1/suppliers")]
public class SupplierController : ControllerBase
{
    private readonly IMediator _mediator;

    public SupplierController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? name, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllSuppliersQuery(name, page, pageSize);
        var suppliers = await _mediator.Send(query);
        return Ok(suppliers);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var query = new GetSupplierByIdQuery(id);
        var supplier = await _mediator.Send(query);
        return Ok(supplier);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSupplierCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { Id = id }, command);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateSupplierInputModel input)
    {
        var command = new UpdateSupplierCommand(id, input.Name, input.Contact);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id) 
    {
        var command = new DeleteSupplierCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
