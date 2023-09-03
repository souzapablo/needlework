using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeedleWork.Application.Features.Login;
using NeedleWork.Application.InputModels.Login;

namespace NeedleWork.API.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginInputModel request)
    {
        LoginCommand command = new(request.Email, request.Password);

        string token = await _mediator.Send(command);

        return Ok(token);
    }
}