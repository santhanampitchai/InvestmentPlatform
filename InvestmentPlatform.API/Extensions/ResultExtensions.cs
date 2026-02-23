using InvestmentPlatform.Domain.Common;
using Microsoft.AspNetCore.Mvc;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(
        this Result<T> result,
        ControllerBase controller)
    {
        if (result.IsFailure)
            return controller.BadRequest(result.Error);

        return controller.Ok(result.Value);
    }
}