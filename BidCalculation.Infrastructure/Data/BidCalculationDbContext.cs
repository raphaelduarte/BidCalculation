using BidCalculation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BidCalculation.Infrastructure.Data;

public class BidCalculationDbContext : DbContext
{
    public BidCalculationDbContext(DbContextOptions<BidCalculationDbContext> options) : base(options) { }

    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<Bid> Bids { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.Auction)
            .WithMany(a => a.Vehicles)
            .HasForeignKey(v => v.AuctionId);

        modelBuilder.Entity<Bid>()
            .HasOne(b => b.Auction)
            .WithMany(a => a.Bids)
            .HasForeignKey(b => b.AuctionId);
    }
}