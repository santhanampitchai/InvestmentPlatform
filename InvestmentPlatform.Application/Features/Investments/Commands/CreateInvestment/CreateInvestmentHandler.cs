using InvestmentPlatform.Application.Common.Interfaces;

using InvestmentPlatform.Domain.Common;
using InvestmentPlatform.Domain.Entities;
using MediatR;

public class CreateInvestmentHandler
    : IRequestHandler<CreateInvestmentCommand, Result<Guid>>
{
    private readonly IInvestmentRepository _repository;
    private readonly ICurrentUserService _currentUser;

    public CreateInvestmentHandler(
        IInvestmentRepository repository,
        ICurrentUserService currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<Result<Guid>> Handle(
        CreateInvestmentCommand request,
        CancellationToken cancellationToken)
    {
        var result = Investment.Create(
            _currentUser.UserId,
            request.Name,
            request.Type,
            request.Amount,
            request.Quantity,
            request.PurchaseDate);

        if (result.IsFailure)
            return Result<Guid>.Failure(result.Error!);

        await _repository.AddAsync(result.Value!, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(result.Value!.Id);
    }
}