using InvestmentPlatform.Domain.Common;
using InvestmentPlatform.Domain.Errors;

namespace InvestmentPlatform.Domain.Entities;

public class Investment
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Name { get; private set; } = default!;
    public InvestmentType Type { get; private set; }
    public decimal Amount { get; private set; }
    public int Quantity { get; private set; }
    public DateTime PurchaseDate { get; private set; }

    private Investment() { } // EF

    private Investment(
        Guid userId,
        string name,
        InvestmentType type,
        decimal amount,
        int quantity,
        DateTime purchaseDate)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Name = name;
        Type = type;
        Amount = amount;
        Quantity = quantity;
        PurchaseDate = purchaseDate;
    }

    public static Result<Investment> Create(
        Guid userId,
        string name,
        InvestmentType type,
        decimal amount,
        int quantity,
        DateTime purchaseDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result<Investment>.Failure(InvestmentErrors.EmptyName);

        if (amount <= 0)
            return Result<Investment>.Failure(InvestmentErrors.InvalidAmount);

        if (quantity <= 0)
            return Result<Investment>.Failure(InvestmentErrors.InvalidQuantity);

        var investment = new Investment(
            userId,
            name,
            type,
            amount,
            quantity,
            purchaseDate);

        return Result<Investment>.Success(investment);
    }

    public Result UpdateAmount(decimal newAmount)
    {
        if (newAmount <= 0)
            return Result.Failure(InvestmentErrors.InvalidAmount);

        Amount = newAmount;
        return Result.Success();
    }
}