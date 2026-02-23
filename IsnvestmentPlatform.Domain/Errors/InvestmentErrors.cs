namespace InvestmentPlatform.Domain.Errors;

using InvestmentPlatform.Domain.Common;

public static class InvestmentErrors
{
    public static readonly Error InvalidAmount =
        new("INVESTMENT.INVALID_AMOUNT", "Amount must be greater than zero.");

    public static readonly Error InvalidQuantity =
        new("INVESTMENT.INVALID_QUANTITY", "Quantity must be greater than zero.");

    public static readonly Error EmptyName =
        new("INVESTMENT.EMPTY_NAME", "Investment name cannot be empty.");
}