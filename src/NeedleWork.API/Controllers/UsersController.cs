using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeedleWork.Application.Features.Users.Commands.Create;

namespace NeedleWork.API.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        long id = await _mediator.Send(command);
        return Ok(id);
    }
}