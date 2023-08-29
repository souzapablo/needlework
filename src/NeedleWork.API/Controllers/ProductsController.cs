using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeedleWork.Application.Features.Products.Commands.Create;
using NeedleWork.Application.Features.Products.Queries.Get;
using NeedleWork.Application.Features.Products.Queries.GetById;
using NeedleWork.Application.ViewModels.Products;
using NeedleWork.Core.Shared;
using NeedleWork.Infrastructure.Shared;

namespace NeedleWork.API.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(
        string? searchTerm,
        string? sortColumn,
        string? sortOrder,
        int page = Constants.Page,
        int pageSize = Constants.PageSize)
    {
        GetProductsQuery query = new(searchTerm, sortColumn, sortOrder, page, pageSize);
        PagedList<ProductViewModel> result = await _mediator.Send(query);
        return Ok(result);
    }


    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        GetProductByIdQuery query = new(id);
        ProductDetailsViewModel result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        long id = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateProduct), new { Id = id }, command);
    }
}