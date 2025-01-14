using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Application.Expenses.Add;
using Tracker.Application.Incomes.Add;
using Tracker.Application.Users.Delete;

namespace Tracker.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddExpenseRequest addExpenseRequest)
    {
        var command = new AddExpenseCommand(addExpenseRequest.UserId, addExpenseRequest.Amount, addExpenseRequest.Unit, addExpenseRequest.Date, addExpenseRequest.Description);
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
