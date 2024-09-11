using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BidCalculation.Infrastructure.Data;

public class BidCalculationDbContextFactory : IDesignTimeDbContextFactory<BidCalculationDbContext>
{
    public BidCalculationDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "BidCalculation.API"))
            .AddJsonFile("appsettings.json", optional: false)
            .Build();


        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'BidCalculationDatabase' not found.");
        }

        var optionsBuilder = new DbContextOptionsBuilder<BidCalculationDbContext>();
        optionsBuilder.UseSqlite(connectionString);

        return new BidCalculationDbContext(optionsBuilder.Options);
    }
}