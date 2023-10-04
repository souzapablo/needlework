using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeedleWork.Application.Features.Addresses;
using NeedleWork.Application.Features.Users.Commands.Create;
using NeedleWork.Application.Features.Users.Commands.Delete;
using NeedleWork.Application.Features.Users.Queries.Get;
using NeedleWork.Application.Features.Users.Queries.GetById;
using NeedleWork.Application.InputModels.Addresses;
using NeedleWork.Application.ViewModels.Users;
using NeedleWork.Core.Shared;
using NeedleWork.Infrastructure.Shared;

namespace NeedleWork.API.Controllers;

[ApiController]
[Route("api/v1/users")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = Constants.AuthorizeAdmin)]
    public async Task<IActionResult> GetUsers(        
        string? searchTerm,
        string? sortColumn,
        string? sortOrder,
        int page = Constants.Page,
        int pageSize = Constants.PageSize)
    {
        GetUsersQuery query = new(searchTerm, sortColumn, sortOrder, page, pageSize);
        PagedList<UserViewModel> result = await _mediator.Send(query);   
        return Ok(result);
    }

    [HttpGet("{id:long}")]
    [Authorize(Roles = Constants.AuthorizeAdmin)]
    public async Task<IActionResult> GetUserById(long id)
    {
        GetUserByIdQuery query = new(id);
        UserDetailsViewModel userDetailsViewModel = await _mediator.Send(query);
        return Ok(userDetailsViewModel);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        long id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetUserById), new { Id = id }, command);
    }
    
    [HttpPost("{id:long}/address")]
    public async Task<IActionResult> AddAddress(long id, CreateAddressInputModel input)
    {
        CreateAddressCommand command = new(id, input.Cep, input.Number, input.Complement);
        
        long addressId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetUserById), new { Id = addressId }, command);
    }

    [HttpDelete("{id:long}")]
    [Authorize(Roles = Constants.AuthorizeAdmin)]
    public async Task<IActionResult> DeleteUser(long id)
    {
        DeleteUserCommand command = new(id);
        await _mediator.Send(command);
        return NoContent();
    }
}