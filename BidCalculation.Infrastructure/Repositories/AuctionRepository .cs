using BidCalculation.Domain.Entities;
using BidCalculation.Domain.Repositories;
using BidCalculation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BidCalculation.Infrastructure.Repositories;

public class AuctionRepository : IAuctionRepository
{
    private readonly BidCalculationDbContext _context;

    public AuctionRepository(BidCalculationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Auction auction)
    {
        await _context.Auctions.AddAsync(auction);
        await _context.SaveChangesAsync();
    }

    public async Task<Auction> FindByIdAsync(Guid id)
    {
        return await _context.Auctions.FindAsync(id);
    }

    public async Task<IEnumerable<Auction>> GetAllAsync()
    {
        return await _context.Auctions.ToListAsync();
    }

    public async Task UpdateAsync(Auction auction)
    {
        _context.Auctions.Update(auction);
        await _context.SaveChangesAsync();
    }
}