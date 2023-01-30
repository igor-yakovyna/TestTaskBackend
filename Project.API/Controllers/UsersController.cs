using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Common.Models;
using Project.Application.Queries.GetUser;
using Project.Application.Queries.GetUsersList;
using Project.Application.Commands.UpdateUser;

namespace Project.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IMediator _mediator;

    public UsersController(ILogger<UsersController> logger,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<UserViewModel>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllUsers()
    {
        var query = new GetUsersListQuery();
        var users = await _mediator.Send(query);

        return Ok(users);
    }
    
    [HttpGet("{userId}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUser([FromRoute] Guid userId)
    {
        var query = new GetUserQuery { UserId = userId };
        var user = await _mediator.Send(query);

        if (user is null)
        {
            return NotFound("User with {userId} does not exists.");
        }

        return Ok(user);
    }

    [HttpPut]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateUsers([FromBody] UpdateUsersCommand command)
    {
        if (command is null)
        {
            return BadRequest("The request body cannot be empty. Need to specify a list of users to save.");
        }

        await _mediator.Send(command);

        return NoContent();
    }
}