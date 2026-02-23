using InvestmentPlatform.Domain.Exceptions;

namespace InvestmentPlatform.Domain.Entities
{
    public class Investment
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public InvestmentType Type { get; private set; }
        public decimal Amount { get; private set; }
        public int Quantity { get; private set; }
        public DateTime PurchaseDate { get; private set; }

        private Investment() { } // EF

        public Investment(Guid userId, string name, InvestmentType type,
                          decimal amount, int quantity, DateTime purchaseDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Investment name is required.");

            if (amount <= 0)
                throw new DomainException("Amount must be greater than zero.");

            if (quantity <= 0)
                throw new DomainException("Quantity must be greater than zero.");

            Id = Guid.NewGuid();
            UserId = userId;
            Name = name;
            Type = type;
            Amount = amount;
            Quantity = quantity;
            PurchaseDate = purchaseDate;
        }
    }
}
