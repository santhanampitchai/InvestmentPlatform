using MediatR;

public record CreateInvestmentCommand(
    string Name,
    InvestmentType Type,
    decimal Amount,
    int Quantity,
    DateTime PurchaseDate
) : IRequest<Guid>;