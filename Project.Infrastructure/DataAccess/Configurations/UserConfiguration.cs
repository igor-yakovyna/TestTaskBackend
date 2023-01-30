using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.FirstName)
            .IsRequired();
        
        builder.Property(e => e.LastName)
            .IsRequired();
        
        builder.Property(e => e.DateOfBirth)
            .IsRequired();
        
        builder.Property(e => e.PhoneNumber)
            .IsRequired();
        
        builder.Property(e => e.FirstName)
            .IsRequired();
        
        builder.Property(e => e.CreatedDateTime)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");
    }
}