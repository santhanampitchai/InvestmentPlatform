using MediatR;
using InvestmentPlatform.Domain.Entities;
using InvestmentPlatform.Application.Common.Interfaces;

public class CreateInvestmentHandler
    : IRequestHandler<CreateInvestmentCommand, Guid>
{
    private readonly IInvestmentRepository _repository;
    private readonly ICurrentUserService _currentUser;

    public CreateInvestmentHandler(
        IInvestmentRepository repository,
        ICurrentUserService currentUser
        )
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<Guid> Handle(
        CreateInvestmentCommand request,
        CancellationToken cancellationToken)
    {
        var investment = new Investment(
            _currentUser.UserId,
            request.Name,
            request.Type,
            request.Amount,
            request.Quantity,
            request.PurchaseDate);

        await _repository.AddAsync(investment, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return investment.Id;
    }
}