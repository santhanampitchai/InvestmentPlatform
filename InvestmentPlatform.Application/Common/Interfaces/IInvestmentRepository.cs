using InvestmentPlatform.Domain.Entities;

namespace InvestmentPlatform.Application.Common.Interfaces;

public interface IInvestmentRepository
{
    Task AddAsync(Investment investment, CancellationToken cancellationToken);
    Task<Investment?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Investment>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    Task RemoveAsync(Investment investment, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}