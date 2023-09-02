using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeedleWork.Application.Features.Users.Commands.Create;
using NeedleWork.Application.Features.Users.Queries.GetById;
using NeedleWork.Application.ViewModels.Users;

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

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetUserById(long id)
    {
        GetUserByIdQuery query = new(id);
        UserDetailsViewModel userDetailsViewModel = await _mediator.Send(query);
        return Ok(userDetailsViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        long id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetUserById), new { Id = id }, command);
    }
}