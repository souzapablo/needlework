using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeedleWork.Application.Features.Suppliers.Commands.Create;
using NeedleWork.Application.Features.Suppliers.Queries.Get;
using NeedleWork.Application.Features.Suppliers.Queries.GetById;
using NeedleWork.Application.ViewModels.Suppliers;

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

    [HttpGet]
    public async Task<IActionResult> GetSuppliers(
        string? serachTerm,
        string? sortColumn,
        string? sortOrder)
    {
        GetSuppliersQuery query = new(serachTerm, sortColumn, sortOrder);
        List<SupplierViewModel> result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetSupplierById(long id)
    {
        GetSupplierByIdQuery query = new(id);
        SupplierDetailsViewModel result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierCommand command)
    {
        long id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetSupplierById), new { Id = id }, command);
    }
}