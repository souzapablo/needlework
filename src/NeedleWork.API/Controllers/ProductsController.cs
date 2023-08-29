using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeedleWork.Application.Features.Products.Create;

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

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        long id = await _mediator.Send(command);
        return Ok(id);
    }
}