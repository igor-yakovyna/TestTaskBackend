using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.DataAccess.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");

        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Street)
            .IsRequired();
        
        builder.Property(e => e.HouseNumber)
            .IsRequired();
        
        builder.Property(e => e.Town)
            .IsRequired();

        builder.Property(e => e.PostalCode)
            .IsRequired();

        builder.HasOne(e => e.User)
            .WithOne(e => e.Address)
            .HasForeignKey<Address>(e => e.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}