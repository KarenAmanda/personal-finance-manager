using Application.CommandsQueries.User.Queries;
using Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Commands.RegisterUser;

namespace UserService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region command

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
    {
        var result = await _mediator.Send(command);

        if (result == null || result.Id == Guid.Empty)
        {
            return StatusCode(500, null);
        }

        return CreatedAtAction(nameof(GetUserByIdAsync), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync(Guid id)
    {
        var userDTO = await _mediator.Send(new GetUserByIdQuery(id));

        if (userDTO == null)
            return NotFound();

        return Ok(userDTO);
    }
    #endregion

}
