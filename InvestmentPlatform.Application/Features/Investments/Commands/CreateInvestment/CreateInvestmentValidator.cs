using FluentValidation;

public class CreateInvestmentValidator
    : AbstractValidator<CreateInvestmentCommand>
{
    public CreateInvestmentValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Amount).GreaterThan(0);
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.PurchaseDate)
            .LessThanOrEqualTo(DateTime.UtcNow);
    }
}