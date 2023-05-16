using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeedleWork.Application.Features.Suppliers.Commands.Create;
using NeedleWork.Application.Features.Suppliers.Queries.GetAll;

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
    public IActionResult GetById(long id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSupplierCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { Id = id }, command);
    }

    [HttpPut("{id:long}")]
    public IActionResult Update(long id)
    {
        return Ok();
    }

    [HttpDelete("{id:long}")]
    public IActionResult Delete(long id) 
    {
        return Ok();
    }
}
