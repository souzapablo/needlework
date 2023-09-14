﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeedleWork.Application.Features.Purchases.Commands.Create;
using NeedleWork.Application.Features.Purchases.Queries.GetById;
using NeedleWork.Application.ViewModels.Purchases;

namespace NeedleWork.API.Controllers;

[ApiController]
[Route("api/v1/purchases")]
[Authorize]
public class PurchasesController : ControllerBase
{
    private readonly IMediator _mediator;

    public PurchasesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        GetPurchaseByIdQuery query = new(id);

        PurchaseDetailsViewModel result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePurchase(CreatePurchaseCommand command)
    {
        long id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { Id = id }, command);
    }
}
