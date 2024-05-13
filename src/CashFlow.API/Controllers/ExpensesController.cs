using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers;

public class ExpensesController : CashFlowAPIBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredExpenseJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {
        try
        {
            var useCase = new RegisterExpenseUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new ResponseErrorJson(ex.Message));
        }
        catch
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new ResponseErrorJson("Unknown error")
            );
        }
    }
}
