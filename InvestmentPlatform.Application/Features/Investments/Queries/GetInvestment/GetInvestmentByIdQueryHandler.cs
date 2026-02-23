using InvestmentPlatform.Application.Common.Interfaces;
using InvestmentPlatform.Application.Features.Investments.DTOs;
using InvestmentPlatform.Application.Investments.Queries.GetInvestment;
using MediatR;

namespace InvestmentPlatform.Application.Investments.Queries.GetInvestmentById;

public class GetInvestmentByIdQueryHandler
    : IRequestHandler<GetInvestmentByIdQuery, InvestmentDto>
{
    private readonly IInvestmentRepository _repository;
    private readonly ICurrentUserService _currentUser;

    public GetInvestmentByIdQueryHandler(
        IInvestmentRepository repository,
        ICurrentUserService currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<InvestmentDto> Handle(
        GetInvestmentByIdQuery request,
        CancellationToken cancellationToken)
    {
        //if (!_currentUser.IsAuthenticated)
        //    throw new UnauthorizedAccessException();

        var investment = await _repository
            .GetByIdAsync(request.Id, cancellationToken);

        if (investment is null)
            throw new KeyNotFoundException("Investment not found.");

        return new InvestmentDto
        {
            Id = investment.Id,
            Name = investment.Name,
            Type = (int)investment.Type,
            Amount = investment.Amount,
            Quantity = investment.Quantity,
            PurchaseDate = investment.PurchaseDate
        };
    }
}