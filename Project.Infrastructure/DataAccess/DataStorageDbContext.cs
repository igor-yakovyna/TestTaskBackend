using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Infrastructure.DataAccess.Configurations;

namespace Project.Infrastructure.DataAccess;

public class DataStorageDbContext : DbContext
{
    public DataStorageDbContext(DbContextOptions<DataStorageDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
    }

    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        return base.SaveChanges();
    }
}