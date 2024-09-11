using BidCalculation.Domain.Entities;

namespace BidCalculation.Domain.Repositories;

public interface IAuctionRepository
{
    Task AddAsync(Auction auction);                    
    Task<Auction> GetByIdAsync(int id);                
    Task<IEnumerable<Auction>> GetAllAsync();          
    Task UpdateAsync(Auction auction);                
}