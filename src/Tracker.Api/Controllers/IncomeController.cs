using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Application.Expenses.Add;
using Tracker.Application.Incomes.Add;
using Tracker.Application.Incomes.Delete;

namespace Tracker.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IncomeController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddIncomeRequest addIncomeRequest)
    {
        var command = new AddIncomeCommand(addIncomeRequest.UserId, addIncomeRequest.Amount, addIncomeRequest.Unit, addIncomeRequest.Date, addIncomeRequest.Description);
        var result = await sender.Send(command);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteIncomeCommand(id);
        var result = await sender.Send(command);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
