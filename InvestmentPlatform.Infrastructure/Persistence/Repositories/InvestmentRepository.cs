using Microsoft.EntityFrameworkCore;
using InvestmentPlatform.Domain.Entities;
using InvestmentPlatform.Infrastructure.Persistence;
using InvestmentPlatform.Application.Common.Interfaces;

namespace InvestmentPlatform.Infrastructure.Persistence.Repositories;

public class InvestmentRepository : IInvestmentRepository
{
    private readonly ApplicationDbContext _context;

    public InvestmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        Investment investment,
        CancellationToken cancellationToken)
    {
        await _context.Investments.AddAsync(investment, cancellationToken);
    }

    public async Task<Investment?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await _context.Investments
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<Investment>> GetByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken)
    {
        return await _context.Investments
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.PurchaseDate)
            .ToListAsync(cancellationToken);
    }

    public Task RemoveAsync(
        Investment investment,
        CancellationToken cancellationToken)
    {
        _context.Investments.Remove(investment);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}