﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Application.Users.Add;
using Tracker.Application.Users.Delete;
using Tracker.Application.Users.Login;

namespace Tracker.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddUserRequest addUserRequest)
    {
        var command = new AddUserCommand(addUserRequest.FirstName, addUserRequest.LastName, addUserRequest.Email);
        var result = await sender.Send(command);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest loginUserRequest)
    {
        var command = new LoginUserCommand(loginUserRequest.Email);
        var result = await sender.Send(command);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteUserCommand(id);
        var result = await sender.Send(command);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
