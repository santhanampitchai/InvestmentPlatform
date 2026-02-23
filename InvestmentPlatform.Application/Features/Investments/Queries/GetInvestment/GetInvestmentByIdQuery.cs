using MediatR;

namespace InvestmentPlatform.Application.Investments.Queries.GetInvestment;

public record GetInvestmentByIdQuery(Guid Id) : IRequest<InvestmentDto>;