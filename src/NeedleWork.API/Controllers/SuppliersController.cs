using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeedleWork.Application.Features.Suppliers.Commands.Create;
using NeedleWork.Application.Features.Suppliers.Commands.Delete;
using NeedleWork.Application.Features.Suppliers.Commands.UpdateName;
using NeedleWork.Application.Features.Suppliers.Queries.Get;
using NeedleWork.Application.Features.Suppliers.Queries.GetById;
using NeedleWork.Application.InputModels.Suppliers;
using NeedleWork.Application.ViewModels.Suppliers;
using NeedleWork.Infrastructure.Shared;

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
        string? searchTerm,
        string? sortColumn,
        string? sortOrder,
        int page,
        int pageSize)
    {
        GetSuppliersQuery query = new(searchTerm, sortColumn, sortOrder, page, pageSize);
        PagedList<SupplierViewModel> result = await _mediator.Send(query);
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

    [HttpPatch("{id:long}/contact")]
    public async Task<IActionResult> UpdateSupplierContact(long id, [FromBody] UpdateSupplierContactInputModel input)
    {
        UpdateSupplierContactCommand command = new(id, input.NewContact);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteSupplier(long id)
    {
        DeleteSupplierCommand command = new(id);
        await _mediator.Send(command);
        return NoContent();
    }
}