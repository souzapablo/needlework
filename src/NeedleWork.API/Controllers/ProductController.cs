using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeedleWork.Application.Features.Products.Commands.Create;
using NeedleWork.Application.Features.Products.Commands.Delete;
using NeedleWork.Application.Features.Products.Commands.Update;
using NeedleWork.Application.Features.Products.Queries.GetAll;
using NeedleWork.Application.Features.Products.Queries.GetById;
using NeedleWork.Application.InputModels.Products;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NeedleWork.API.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? description,[FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetAllProductsQuery(description, page, pageSize);
        var products = await _mediator.Send(query); 
        return Ok(products);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var query = new GetProductByIdQuery(id);
        var product = await _mediator.Send(query);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { Id = id }, command);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, UpdateProductInputModel input)
    {
        var command = new UpdateProductCommand(id, input.Description, input.Price);
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var command = new DeleteProductCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
