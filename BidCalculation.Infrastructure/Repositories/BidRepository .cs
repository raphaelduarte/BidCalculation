using BidCalculation.Domain.Entities;
using BidCalculation.Domain.Repositories;
using BidCalculation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BidCalculation.Infrastructure.Repositories;

public class BidRepository : IBidRepository
{
    private readonly BidCalculationDbContext _context;

    public BidRepository(BidCalculationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Bid bid)
    {
        await _context.Bids.AddAsync(bid);
        await _context.SaveChangesAsync();
    }

    public async Task<Bid?> FindByIdAsync(Guid id)
    {
        return await _context.Bids.FindAsync(id);
    }

    public async Task<IEnumerable<Bid>> GetAllAsync()
    {
        return await _context.Bids.ToListAsync();
    }

    public async Task UpdateAsync(Bid bid)
    {
        _context.Bids.Update(bid);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Bid bid)
    {
        _context.Bids.Remove(bid);
        await _context.SaveChangesAsync();
    }
}