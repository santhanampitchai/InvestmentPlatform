using InvestmentPlatform.Application.Investments.Queries.GetInvestment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class InvestmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public InvestmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateInvestmentCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }
    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetInvestmentByIdQuery(id));
        return Ok(result);
    }
}