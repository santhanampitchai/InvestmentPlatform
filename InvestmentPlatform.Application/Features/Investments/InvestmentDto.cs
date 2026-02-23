namespace InvestmentPlatform.Application.Investments;

public class InvestmentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public int Type { get; set; }
    public decimal Amount { get; set; }
    public int Quantity { get; set; }
    public DateTime PurchaseDate { get; set; }
}